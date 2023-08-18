using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FFXIVFashionReport
{
    public partial class MainWindow : Window
    {
        #region declare
        private static string Key = "cd6f068c506d418fa1699cc4e86772ccc05bdc574a664f2ba5db3db179f87a7f";
        private List<string> languageList = new List<string> { "Fr", "De", "Ja", "En" };
        private List<string> EquipmentList = new List<string> { "Weapon", "Head", "Body", "Hands", "Legs", "Shoes", "Earrings", "Necklace", "Bracelets", "Ring1", "Ring2" };
        private HttpClient _httpClient;
        private const string ApiBaseUrl = "https://xivapi.com/search";
        private const int MillisecondsDelay = 1000;
        private const int SaveMillisecondsDelay = 2000;
        private Item _Weapon_selectedItem;
        private Item _Head_selectedItem;
        private Item _Body_selectedItem;
        private Item _Hands_selectedItem;
        private Item _Legs_selectedItem;
        private Item _Shoes_selectedItem;
        private Item _Earrings_selectedItem;
        private Item _Necklace_selectedItem;
        private Item _Bracelets_selectedItem;
        private Item _Ring1_selectedItem;
        private Item _Ring2_selectedItem;

        public ObservableCollection<Item> Weapon_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Head_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Body_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Hands_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Legs_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Shoes_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Earrings_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Necklace_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Bracelets_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Ring1_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Ring2_Results { get; } = new ObservableCollection<Item>();

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            Weapon_Filtered.ItemsSource = Weapon_Results;
            Head_Filtered.ItemsSource = Head_Results;
            Body_Filtered.ItemsSource = Body_Results;
            Body_Filtered.ItemsSource = Hands_Results;
            Body_Filtered.ItemsSource = Legs_Results;
            Body_Filtered.ItemsSource = Shoes_Results;
            Body_Filtered.ItemsSource = Earrings_Results;
            Body_Filtered.ItemsSource = Necklace_Results;
            Body_Filtered.ItemsSource = Bracelets_Results;
            Body_Filtered.ItemsSource = Ring1_Results;
            Body_Filtered.ItemsSource = Ring2_Results;
        }
        #endregion

        #region Weapon
        private async void Weapon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                e.Handled = true;
                await SearchInfos(Weapon_imgSelectedIcon, Weapon_txtSelectedName, Weapon_selectedResultPanel, Weapon, Weapon_Popup, Weapon_Filtered, _Weapon_selectedItem);
            }
        }

        private void Weapon_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Weapon_Filtered.SelectedItem != null)
            {
                _Weapon_selectedItem = (Item)Weapon_Filtered.SelectedItem;
                UpdateSelectedResultUI(Weapon_imgSelectedIcon, Weapon_txtSelectedName, Weapon_selectedResultPanel, Weapon, Weapon_Popup, _Weapon_selectedItem);

                Weapon_Popup.IsOpen = false;
            }
        }

        private void Weapon_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Weapon_selectedItem = null;
            UpdateSelectedResultUI(Weapon_imgSelectedIcon, Weapon_txtSelectedName, Weapon_selectedResultPanel, Weapon, Weapon_Popup, _Weapon_selectedItem);
        }
        #endregion

        #region Head
        private async void Head_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Head_imgSelectedIcon, Head_txtSelectedName, Head_selectedResultPanel, Head, Head_Popup, Head_Filtered, _Head_selectedItem);
            }
        }

        private void Head_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Head_Filtered.SelectedItem != null)
            {
                _Head_selectedItem = (Item)Head_Filtered.SelectedItem;
                UpdateSelectedResultUI(Head_imgSelectedIcon, Head_txtSelectedName, Head_selectedResultPanel, Head, Head_Popup, _Head_selectedItem);

                Head_Popup.IsOpen = false;
            }
        }

        private void Head_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Head_selectedItem = null;
            UpdateSelectedResultUI(Head_imgSelectedIcon, Head_txtSelectedName, Head_selectedResultPanel, Head, Head_Popup, _Head_selectedItem);
        }
        #endregion

        #region Body
        private async void Body_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Body_imgSelectedIcon, Body_txtSelectedName, Body_selectedResultPanel, Body, Body_Popup, Body_Filtered, _Body_selectedItem);
            }
        }

        private void Body_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Body_Filtered.SelectedItem != null)
            {
                _Body_selectedItem = (Item)Body_Filtered.SelectedItem;
                UpdateSelectedResultUI(Body_imgSelectedIcon, Body_txtSelectedName, Body_selectedResultPanel, Body, Body_Popup, _Body_selectedItem);

                Body_Popup.IsOpen = false;
            }
        }

        private void Body_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Body_selectedItem = null;
            UpdateSelectedResultUI(Body_imgSelectedIcon, Body_txtSelectedName, Body_selectedResultPanel, Body, Body_Popup, _Body_selectedItem);
        }
        #endregion

        #region Hands
        private async void Hands_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Hands_imgSelectedIcon, Hands_txtSelectedName, Hands_selectedResultPanel, Hands, Hands_Popup, Hands_Filtered, _Hands_selectedItem);
            }
        }

        private void Hands_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Hands_Filtered.SelectedItem != null)
            {
                _Hands_selectedItem = (Item)Hands_Filtered.SelectedItem;
                UpdateSelectedResultUI(Hands_imgSelectedIcon, Hands_txtSelectedName, Hands_selectedResultPanel, Hands, Hands_Popup, _Hands_selectedItem);

                Hands_Popup.IsOpen = false;
            }
        }

        private void Hands_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Hands_selectedItem = null;
            UpdateSelectedResultUI(Hands_imgSelectedIcon, Hands_txtSelectedName, Hands_selectedResultPanel, Hands, Hands_Popup, _Hands_selectedItem);
        }
        #endregion

        #region Legs
        private async void Legs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Legs_imgSelectedIcon, Legs_txtSelectedName, Legs_selectedResultPanel, Legs, Legs_Popup, Legs_Filtered, _Legs_selectedItem);
            }
        }

        private void Legs_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Legs_Filtered.SelectedItem != null)
            {
                _Legs_selectedItem = (Item)Legs_Filtered.SelectedItem;
                UpdateSelectedResultUI(Legs_imgSelectedIcon, Legs_txtSelectedName, Legs_selectedResultPanel, Legs, Legs_Popup, _Legs_selectedItem);

                Legs_Popup.IsOpen = false;
            }
        }

        private void Legs_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Legs_selectedItem = null;
            UpdateSelectedResultUI(Legs_imgSelectedIcon, Legs_txtSelectedName, Legs_selectedResultPanel, Legs, Legs_Popup, _Legs_selectedItem);
        }
        #endregion

        #region Shoes
        private async void Shoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Shoes_imgSelectedIcon, Shoes_txtSelectedName, Shoes_selectedResultPanel, Shoes, Shoes_Popup, Shoes_Filtered, _Shoes_selectedItem);
            }
        }

        private void Shoes_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Shoes_Filtered.SelectedItem != null)
            {
                _Shoes_selectedItem = (Item)Shoes_Filtered.SelectedItem;
                UpdateSelectedResultUI(Shoes_imgSelectedIcon, Shoes_txtSelectedName, Shoes_selectedResultPanel, Shoes, Shoes_Popup, _Shoes_selectedItem);

                Shoes_Popup.IsOpen = false;
            }
        }

        private void Shoes_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Shoes_selectedItem = null;
            UpdateSelectedResultUI(Shoes_imgSelectedIcon, Shoes_txtSelectedName, Shoes_selectedResultPanel, Shoes, Shoes_Popup, _Shoes_selectedItem);
        }
        #endregion

        #region Earrings
        private async void Earrings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Earrings_imgSelectedIcon, Earrings_txtSelectedName, Earrings_selectedResultPanel, Earrings, Earrings_Popup, Earrings_Filtered, _Earrings_selectedItem);
            }
        }

        private void Earrings_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Earrings_Filtered.SelectedItem != null)
            {
                _Earrings_selectedItem = (Item)Earrings_Filtered.SelectedItem;
                UpdateSelectedResultUI(Earrings_imgSelectedIcon, Earrings_txtSelectedName, Earrings_selectedResultPanel, Earrings, Earrings_Popup, _Earrings_selectedItem);

                Earrings_Popup.IsOpen = false;
            }
        }

        private void Earrings_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Earrings_selectedItem = null;
            UpdateSelectedResultUI(Earrings_imgSelectedIcon, Earrings_txtSelectedName, Earrings_selectedResultPanel, Earrings, Earrings_Popup, _Earrings_selectedItem);
        }
        #endregion

        #region Necklace
        private async void Necklace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Necklace_imgSelectedIcon, Necklace_txtSelectedName, Necklace_selectedResultPanel, Necklace, Necklace_Popup, Necklace_Filtered, _Necklace_selectedItem);
            }
        }

        private void Necklace_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Necklace_Filtered.SelectedItem != null)
            {
                _Necklace_selectedItem = (Item)Necklace_Filtered.SelectedItem;
                UpdateSelectedResultUI(Necklace_imgSelectedIcon, Necklace_txtSelectedName, Necklace_selectedResultPanel, Necklace, Necklace_Popup, _Necklace_selectedItem);

                Necklace_Popup.IsOpen = false;
            }
        }

        private void Necklace_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Necklace_selectedItem = null;
            UpdateSelectedResultUI(Necklace_imgSelectedIcon, Necklace_txtSelectedName, Necklace_selectedResultPanel, Necklace, Necklace_Popup, _Necklace_selectedItem);
        }
        #endregion

        #region Bracelets
        private async void Bracelets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Bracelets_imgSelectedIcon, Bracelets_txtSelectedName, Bracelets_selectedResultPanel, Bracelets, Bracelets_Popup, Bracelets_Filtered, _Bracelets_selectedItem);
            }
        }

        private void Bracelets_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Bracelets_Filtered.SelectedItem != null)
            {
                _Bracelets_selectedItem = (Item)Bracelets_Filtered.SelectedItem;
                UpdateSelectedResultUI(Bracelets_imgSelectedIcon, Bracelets_txtSelectedName, Bracelets_selectedResultPanel, Bracelets, Bracelets_Popup, _Bracelets_selectedItem);

                Bracelets_Popup.IsOpen = false;
            }
        }

        private void Bracelets_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Bracelets_selectedItem = null;
            UpdateSelectedResultUI(Bracelets_imgSelectedIcon, Bracelets_txtSelectedName, Bracelets_selectedResultPanel, Bracelets, Bracelets_Popup, _Bracelets_selectedItem);
        }
        #endregion

        #region Ring1
        private async void Ring1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Ring1_imgSelectedIcon, Ring1_txtSelectedName, Ring1_selectedResultPanel, Ring1, Ring1_Popup, Ring1_Filtered, _Ring1_selectedItem);
            }
        }

        private void Ring1_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Ring1_Filtered.SelectedItem != null)
            {
                _Ring1_selectedItem = (Item)Ring1_Filtered.SelectedItem;
                UpdateSelectedResultUI(Ring1_imgSelectedIcon, Ring1_txtSelectedName, Ring1_selectedResultPanel, Ring1, Ring1_Popup, _Ring1_selectedItem);

                Ring1_Popup.IsOpen = false;
            }
        }

        private void Ring1_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Ring1_selectedItem = null;
            UpdateSelectedResultUI(Ring1_imgSelectedIcon, Ring1_txtSelectedName, Ring1_selectedResultPanel, Ring1, Ring1_Popup, _Ring1_selectedItem);
        }
        #endregion

        #region Ring2
        private async void Ring2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Ring2_imgSelectedIcon, Ring2_txtSelectedName, Ring2_selectedResultPanel, Ring2, Ring2_Popup, Ring2_Filtered, _Ring2_selectedItem);
            }
        }

        private void Ring2_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Ring2_Filtered.SelectedItem != null)
            {
                _Ring2_selectedItem = (Item)Ring2_Filtered.SelectedItem;
                UpdateSelectedResultUI(Ring2_imgSelectedIcon, Ring2_txtSelectedName, Ring2_selectedResultPanel, Ring2, Ring2_Popup, _Ring2_selectedItem);

                Ring2_Popup.IsOpen = false;
            }
        }

        private void Ring2_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Ring2_selectedItem = null;
            UpdateSelectedResultUI(Ring2_imgSelectedIcon, Ring2_txtSelectedName, Ring2_selectedResultPanel, Ring2, Ring2_Popup, _Ring2_selectedItem);
        }
        #endregion

        #region Equipments
        private void ClearResults(TextBox textBox)
        {
            switch (textBox.Name)
            {
                case "Weapon":
                    Weapon_Results.Clear();
                    break;
                case "Head":
                    Head_Results.Clear();
                    break;
                case "Body":
                    Body_Results.Clear();
                    break;
                case "Hands":
                    Hands_Results.Clear();
                    break;
                case "Legs":
                    Legs_Results.Clear();
                    break;
                case "Shoes":
                    Shoes_Results.Clear();
                    break;
                case "Earrings":
                    Earrings_Results.Clear();
                    break;
                case "Necklace":
                    Necklace_Results.Clear();
                    break;
                case "Bracelets":
                    Bracelets_Results.Clear();
                    break;
                case "Ring1":
                    Ring1_Results.Clear();
                    break;
                case "Ring2":
                    Ring2_Results.Clear();
                    break;
                default:
                    break;
            }
        }

        private void StoreItems(TextBox textBox, Item item)
        {
            switch (textBox.Name)
            {
                case "Weapon":
                    Weapon_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Head":
                    Head_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Body":
                    Body_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Hands":
                    Hands_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Legs":
                    Legs_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Shoes":
                    Shoes_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Earrings":
                    Earrings_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Necklace":
                    Necklace_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Bracelets":
                    Bracelets_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Ring1":
                    Ring1_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Ring2":
                    Ring2_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                default:
                    break;
            }
        }

        private List<Item> FiltedItems(TextBox textBox, ListView listView, string filterText, List<Item> filteredItems)
        {
            switch (textBox.Name)
            {
                case "Weapon":
                    filteredItems = Weapon_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Weapon_Results;
                    break;
                case "Head":
                    filteredItems = Head_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Head_Results;
                    break;
                case "Body":
                    filteredItems = Body_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Body_Results;
                    break;
                case "Hands":
                    filteredItems = Hands_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Hands_Results;
                    break;
                case "Legs":
                    filteredItems = Legs_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Legs_Results;
                    break;
                case "Shoes":
                    filteredItems = Shoes_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Shoes_Results;
                    break;
                case "Earrings":
                    filteredItems = Earrings_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Earrings_Results;
                    break;
                case "Necklace":
                    filteredItems = Necklace_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Necklace_Results;
                    break;
                case "Bracelets":
                    filteredItems = Bracelets_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Bracelets_Results;
                    break;
                case "Ring1":
                    filteredItems = Ring1_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Ring1_Results;
                    break;
                case "Ring2":
                    filteredItems = Ring2_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Ring2_Results;
                    break;
                default:
                    break;
            }
            return filteredItems;
        }

        private List<Item> ResultItems(TextBox textBox, ListView listView, string filterText, List<Item> filteredItems)
        {
            switch (textBox.Name)
            {
                case "Weapon":
                    filteredItems = Weapon_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Weapon_Results;
                    break;
                case "Head":
                    filteredItems = Head_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Head_Results;
                    break;
                case "Body":
                    filteredItems = Body_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Body_Results;
                    break;
                case "Hands":
                    filteredItems = Hands_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Hands_Results;
                    break;
                case "Legs":
                    filteredItems = Legs_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Legs_Results;
                    break;
                case "Shoes":
                    filteredItems = Shoes_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Shoes_Results;
                    break;
                case "Earrings":
                    filteredItems = Earrings_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Earrings_Results;
                    break;
                case "Necklace":
                    filteredItems = Necklace_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Necklace_Results;
                    break;
                case "Bracelets":
                    filteredItems = Bracelets_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Bracelets_Results;
                    break;
                case "Ring1":
                    filteredItems = Ring1_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Ring1_Results;
                    break;
                case "Ring2":
                    filteredItems = Ring2_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Ring2_Results;
                    break;
                default:
                    break;
            }

            return filteredItems;
        }
        #endregion

        #region ScreenShot
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

        private void SetVisibility(string typeName, Visibility visibility)
        {
            var textBox = FindName($"{typeName}") as TextBox;
            if(textBox != null )
            {
                textBox.Visibility = visibility;
            }
        }

        private void ResetVisibility(string Equipment, Visibility visibility)
        {
            var textBox = FindName($"{Equipment}") as TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Visibility = visibility;
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
            listName = await GetItemInfoDictionaryAsync(_Shoes_selectedItem, "Shoes", listName);
            listName = await GetItemInfoDictionaryAsync(_Earrings_selectedItem, "Earrings", listName);
            listName = await GetItemInfoDictionaryAsync(_Necklace_selectedItem, "Necklace", listName);
            listName = await GetItemInfoDictionaryAsync(_Bracelets_selectedItem, "Bracelets", listName);
            listName = await GetItemInfoDictionaryAsync(_Ring1_selectedItem, "Ring1", listName);
            listName = await GetItemInfoDictionaryAsync(_Ring2_selectedItem, "Ring2", listName);

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
                var key = $"{Equipment}{language}";
                if (listName.TryGetValue(key, out string value))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(value);
                    string searchText = Encoding.UTF8.GetString(bytes);
                    textBox.Text = BreakNameIntoMultipleLines(searchText);
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
        #endregion

        #region Program
        private async Task SearchInfos(Image image, TextBlock textBlock, StackPanel stackPanel, TextBox textBox, Popup popup, ListView listView, Item _selectedItem)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(textBox.Text);

            string searchText = Encoding.UTF8.GetString(bytes);

            await Task.Delay(MillisecondsDelay);

            ClearResults(textBox);

            var searchTerm = textBox.Text;
            var selectedLanguage = (cmbLanguages.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(selectedLanguage))
            {
                return;
            }

            var apiUrl = $"{ApiBaseUrl}?string={searchTerm}&language={selectedLanguage}&indexes=item,recipe&limit=250&private_key={Key}";

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

                    foreach (var item in apiResponse.Results)
                    {
                        StoreItems(textBox, item);
                    }

                    page++;
                } while (page <= apiResponse.Pagination.PageTotal && apiResponse.Pagination.PageNext != null);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Une erreur s'est produite lors de la requête : {ex.Message}");
            }

            string filterText = textBox.Text.ToLower();
            List<Item> filteredItems = new List<Item>();
            filteredItems = FiltedItems(textBox, listView, filterText, filteredItems);

            if (filterText.Length > 0 && filteredItems.Count > 0)
            {
                popup.IsOpen = true;
            }
            else
            {
                popup.IsOpen = false;
            }

            filteredItems = ResultItems(textBox, listView, filterText, filteredItems);

            UpdateSelectedResultUI(image, textBlock, stackPanel, textBox, popup, _selectedItem);
        }

        private string BreakNameIntoMultipleLines(string name)
        {
            int maxLineLength = 25;

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

                if (lastSpaceIndex <= currentIndex)
                {
                    lastSpaceIndex = currentIndex + lineLength;
                }

                result.AppendLine(name.Substring(currentIndex, lastSpaceIndex - currentIndex));
                currentIndex = lastSpaceIndex + 1;

                while (currentIndex < name.Length && name[currentIndex] == ' ')
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
                image.Source = new BitmapImage(new Uri(_selectedItem.IconUrl));
                textBlock.Text = _selectedItem.Name;
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
        #endregion
    }

    #region Json
    public class ApiResponse
    {
        public List<Item> Results { get; set; }

        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public int Page { get; set; }
        public int PageTotal { get; set; }
        public string PageNext { get; set; }
        public string PagePrev { get; set; }
        public int Results { get; set; }
        public int ResultsPerPage { get; set; }
    }

    public class Item
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Icon")]
        public string Icon { get; set; }

        [JsonProperty("UrlType")]
        public string UrlType { get; set; }

        public string IconUrl => $"https://xivapi.com{Icon}";
    }

    public class Root
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_fr")]
        public string Name_fr { get; set; }

        [JsonProperty("Name_de")]
        public string Name_de { get; set; }

        [JsonProperty("Name_en")]
        public string Name_en { get; set; }

        [JsonProperty("Name_ja")]
        public string Name_ja { get; set; }

        [JsonProperty("Description_de")]
        public string Description_de { get; set; }

        [JsonProperty("Description_en")]
        public string Description_en { get; set; }

        [JsonProperty("Description_fr")]
        public string Description_fr { get; set; }

        [JsonProperty("Description_ja")]
        public string Description_ja { get; set; }

        [JsonProperty("PriceMid")]
        public long PriceMid { get; set; }

        [JsonProperty("ItemUICategory")]
        public ItemKind itemKind { get; set; }

        [JsonProperty("classJobCategory")]
        public ClassJobCategory classJobCategory { get; set; }
        public ItemSoulCrystal itemSoulCrystal { get; set; }
    }

    public class ItemKind
    {
        [JsonProperty("Name_de")]
        public string Name_de { get; set; }

        [JsonProperty("Name_en")]
        public string Name_en { get; set; }

        [JsonProperty("Name_fr")]
        public string Name_fr { get; set; }

        [JsonProperty("Name_ja")]
        public string Name_ja { get; set; }
    }

    public class ClassJobCategory
    {
        [JsonProperty("Name_de")]
        public string Name_de { get; set; }

        [JsonProperty("Name_en")]
        public string Name_en { get; set; }

        [JsonProperty("Name_fr")]
        public string Name_fr { get; set; }

        [JsonProperty("Name_ja")]
        public string Name_ja { get; set; }
    }

    public class ClassJobUse
    {
        [JsonProperty("Name_de")]
        public string Name_de { get; set; }

        [JsonProperty("Name_en")]
        public string Name_en { get; set; }

        [JsonProperty("Name_fr")]
        public string Name_fr { get; set; }

        [JsonProperty("Name_ja")]
        public string Name_ja { get; set; }
    }

    public class ItemSoulCrystal
    {
        public ClassJobUse classJobUse { get; set; }
    }
    #endregion
}
