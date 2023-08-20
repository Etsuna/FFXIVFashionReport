using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

namespace FFXIVFashionReport
{
    public partial class MainWindow
    {
        private async Task SearchInfos(Image image, TextBlock textBlock, StackPanel stackPanel, TextBox textBox, Popup popup, ListView listView, Item _selectedItem)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(textBox.Text);

            string searchText = Encoding.UTF8.GetString(bytes);

            await Task.Delay(MillisecondsDelay);

            ClearResults(textBox);

            var searchTerm = searchText;
            var selectedLanguage = (cmbLanguages.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(selectedLanguage))
            {
                return;
            }

            var apiUrl = $"{ApiBaseUrl}?string={searchTerm}&language={selectedLanguage}&indexes=item,recipe&limit=250&Columns=ItemSearchCategory.ID,ItemUICategory.Name,ItemResult.ItemUICategory.Name,Name,Icon,ID,Url&private_key={Key}";

            try
            {
                int page = 1;
                ApiResponse apiResponse;

                do
                {
                    var response = await _httpClient.GetAsync(apiUrl + $"&page={page}");
                    response.EnsureSuccessStatusCode();

                    var responseBody = await response.Content.ReadAsStringAsync();
                    apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
                    GetItemsByType(textBox, apiResponse);

                    page++;
                } while (page <= apiResponse.Pagination.PageTotal && apiResponse.Pagination.PageNext != null);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de la requête : {ex.Message}");
            }

            string filterText = textBox.Text.ToLower();
            List<Item> filteredItems = new List<Item>();
            filteredItems = FiltedItems(textBox, listView, filterText);

            if (filterText.Length > 0 && filteredItems.Count > 0)
            {
                popup.IsOpen = true;
            }
            else
            {
                popup.IsOpen = false;
            }

            ResultItems(textBox, listView, filterText);

            UpdateSelectedResultUI(image, textBlock, stackPanel, textBox, popup, _selectedItem);
        }

        private void GetItemsByType(TextBox textBox, ApiResponse apiResponse)
        {
            int dyeCategoryId = 54;

            foreach (var item in apiResponse.Results)
            {
                var categoryName = textBox.Name;

                if (!item.itemSearchCategory.ID.HasValue && !categoryName.Contains("Dye"))
                {
                    if (!string.IsNullOrEmpty(item.ItemUICategory.Name) && categoryName.Contains(item.ItemUICategory.Name))
                    {
                        item.itemSearchCategory.ID = EquipementDictionary[categoryName];
                    }
                    else if (!string.IsNullOrEmpty(item.ItemResult.Name) && categoryName.Contains(item.ItemResult.Name))
                    {
                        item.itemSearchCategory.ID = EquipementDictionary[categoryName];
                    }
                }

                if (EquipementDictionary.TryGetValue(categoryName, out var expectedCategoryId))
                {
                    if (expectedCategoryId == null || item.itemSearchCategory.ID == expectedCategoryId)
                    {
                        StoreItems(textBox, item);
                    }
                }
                else if (categoryName == "Weapon" && WeaponList.Contains(item.itemSearchCategory.ID.GetValueOrDefault()))
                {
                    StoreItems(textBox, item);
                }
                else if (categoryName.Contains("Dye") && item.itemSearchCategory.ID == dyeCategoryId)
                {
                    StoreItems(textBox, item);
                }
            }
        }

        private string BreakNameIntoMultipleLines(bool dyeCheck, string name)
        {
            int maxLineLength;
            if (dyeCheck)
            {
                maxLineLength = 10;
            }
            else
            {
                maxLineLength = 25;
            }

            if (name.Length <= maxLineLength)
            {
                return name;
            }

            StringBuilder result = new StringBuilder();
            int currentIndex = 0;

            while (currentIndex < name.Length)
            {
                int remainingLength = name.Length - currentIndex;
                int lineLength = Math.Min(maxLineLength, remainingLength);

                int lastSpaceIndex = name.LastIndexOf(' ', currentIndex + lineLength - 1, lineLength);
                int lastHyphenIndex = name.LastIndexOf('-', currentIndex + lineLength - 1, lineLength);

                if (lastHyphenIndex > lastSpaceIndex)
                {
                    lastSpaceIndex = lastHyphenIndex;
                }

                if (lastSpaceIndex <= currentIndex)
                {
                    lastSpaceIndex = currentIndex + lineLength;
                }

                result.AppendLine(name.Substring(currentIndex, lastSpaceIndex - currentIndex));
                currentIndex = lastSpaceIndex + 1;

                while (currentIndex < name.Length && (name[currentIndex] == ' ' || name[currentIndex] == '-'))
                {
                    currentIndex++;
                }
            }

            return result.ToString().Trim();
        }


        private void UpdateSelectedResultUI(Image image, TextBlock textBlock, StackPanel stackPanel, TextBox textBox, Popup popup, Item _selectedItem)
        {
            if (_selectedItem != null)
            {
                var dyeCheck = false;
                image.Source = new BitmapImage(new Uri(_selectedItem.IconUrl));
                if (textBlock.Name.Contains("Dye"))
                {
                    dyeCheck = true;
                }
                textBlock.Text = BreakNameIntoMultipleLines(dyeCheck, _selectedItem.Name);
                stackPanel.Visibility = Visibility.Visible;

                Point txtSearchTermPosition = textBox.TranslatePoint(new Point(0, 0), this);

                stackPanel.Margin = new Thickness(txtSearchTermPosition.X, txtSearchTermPosition.Y, 0, 0);

                textBox.Visibility = Visibility.Collapsed;

                popup.IsOpen = false;
            }
            else
            {
                stackPanel.Visibility = Visibility.Collapsed;
                textBox.Visibility = Visibility.Visible;
            }
        }

        public async Task<Root> GetItemInfo(int itemId)
        {
            var apiUrl = $"https://xivapi.com/item/{itemId}";
            Root itemInfo = null;
            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                itemInfo = JsonConvert.DeserializeObject<Root>(responseBody);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de la requête : {ex.Message}");
            }

            return itemInfo;
        }
    }
}
