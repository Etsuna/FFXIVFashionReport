using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace FFXIVFashionReport
{
    public partial class MainWindow
    {
        private async Task<Dictionary<string, string>> GetItemInfoDictionaryAsync(Item selectedItem, string typeName, Dictionary<string, string> listName)
        {
            if (selectedItem != null)
            {
                Root itemInfo = await GetItemInfo(selectedItem.ID);
                listName.Add($"{typeName}Fr", itemInfo.Name_fr);
                listName.Add($"{typeName}De", itemInfo.Name_de);
                listName.Add($"{typeName}Ja", itemInfo.Name_ja);
                listName.Add($"{typeName}En", itemInfo.Name_en);
                SetXButtonVisibility(typeName, Visibility.Collapsed);
                SetLinkVisibility(typeName, Visibility.Collapsed);
            }
            else
            {
                SetVisibility(typeName, Visibility.Collapsed);
            }

            return listName;
        }

        private void SetXButtonVisibility(string typeName, Visibility visibility)
        {
            var button = FindName($"{typeName}_btnRemove") as Button;
            if (button != null)
            {
                button.Visibility = visibility;
            }
        }

        private void SetLinkVisibility(string typeName, Visibility visibility)
        {
            var link = FindName($"{typeName}_Link") as Label;
            if (link != null)
            {
                link.Visibility = visibility;
            }
        }

        private void SetVisibility(string typeName, Visibility visibility)
        {
            var textBox = FindName($"{typeName}") as TextBox;
            if (textBox != null)
            {
                textBox.Visibility = visibility;
            }
        }

        private void ResetVisibility(string Equipment, Visibility visibility)
        {
            var textBox = FindName($"{Equipment}") as TextBox;
            var link = FindName($"{Equipment}_Link") as Label;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Visibility = visibility;
            }
            else
            {
                link.Visibility = visibility;
            }
        }

        private async void MakeFashionReport_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var listName = new Dictionary<string, string>();

            listName = await GetItemInfoDictionaryAsync(_Weapon_selectedItem, "Weapon", listName);
            listName = await GetItemInfoDictionaryAsync(_Head_selectedItem, "Head", listName);
            listName = await GetItemInfoDictionaryAsync(_Body_selectedItem, "Body", listName);
            listName = await GetItemInfoDictionaryAsync(_Hands_selectedItem, "Hands", listName);
            listName = await GetItemInfoDictionaryAsync(_Legs_selectedItem, "Legs", listName);
            listName = await GetItemInfoDictionaryAsync(_Feet_selectedItem, "Feet", listName);
            listName = await GetItemInfoDictionaryAsync(_Earrings_selectedItem, "Earrings", listName);
            listName = await GetItemInfoDictionaryAsync(_Necklace_selectedItem, "Necklace", listName);
            listName = await GetItemInfoDictionaryAsync(_Bracelets_selectedItem, "Bracelets", listName);
            listName = await GetItemInfoDictionaryAsync(_Ring1_selectedItem, "Ring1", listName);
            listName = await GetItemInfoDictionaryAsync(_Ring2_selectedItem, "Ring2", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Weapon_selectedItem, "Dye_Weapon", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Head_selectedItem, "Dye_Head", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Body_selectedItem, "Dye_Body", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Hands_selectedItem, "Dye_Hands", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Legs_selectedItem, "Dye_Legs", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Feet_selectedItem, "Dye_Feet", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Earrings_selectedItem, "Dye_Earrings", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Necklace_selectedItem, "Dye_Necklace", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Bracelets_selectedItem, "Dye_Bracelets", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Ring1_selectedItem, "Dye_Ring1", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Ring2_selectedItem, "Dye_Ring2", listName);

            Make_Fashion_Report.Visibility = Visibility.Collapsed;
            cmbLanguages.Visibility = Visibility.Collapsed;
            LanguageTextBlock.Visibility = Visibility.Collapsed;

            await CaptureScreenshotAsync(listName);

            foreach (var equipment in EquipmentList)
            {
                ResetVisibility(equipment, Visibility.Visible);
                SetXButtonVisibility(equipment, Visibility.Visible);
            }

            Make_Fashion_Report.Visibility = Visibility.Visible;
            cmbLanguages.Visibility = Visibility.Visible;
            LanguageTextBlock.Visibility = Visibility.Visible;
        }

        private async Task CaptureScreenshotAsync(Dictionary<string, string> listName)
        {
            foreach (var language in languageList)
            {
                string fileName = $"Fashion_Report_{Fashion_Report_Number.Text}_{language}.png";

                foreach (var equipment in EquipmentList)
                {
                    UpdateTextLanguage(listName, equipment, language);
                }

                await Task.Delay(SaveMillisecondsDelay);
                RenderAndSaveScreenshot(fileName);
            }

            MessageBox.Show("Screenshot captured and saved");
        }

        private void UpdateTextLanguage(Dictionary<string, string> listName, string Equipment, string language)
        {
            var textBox = FindName($"{Equipment}_txtSelectedName") as TextBlock;
            if (textBox != null)
            {
                var dyeCheck = false;
                var key = $"{Equipment}{language}";
                if (listName.TryGetValue(key, out string value))
                {
                    if (textBox.Name.Contains("Dye"))
                    {
                        dyeCheck = true;
                    }
                    byte[] bytes = Encoding.UTF8.GetBytes(value);
                    string searchText = Encoding.UTF8.GetString(bytes);
                    textBox.Text = BreakNameIntoMultipleLines(dyeCheck, searchText);
                }
            }
        }

        private void RenderAndSaveScreenshot(string fileName)
        {
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(
                (int)this.ActualWidth,
                (int)this.ActualHeight,
                96, 96,
                PixelFormats.Default);

            renderTargetBitmap.Render(this);

            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                encoder.Save(fileStream);
            }
        }
    }
}
