using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
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
        private List<string> EquipmentList = new List<string> { "Weapon", "Head", "Body", "Hands", "Legs", "Shoes", "Earrings", "Necklace", "Bracelets", "Ring1", "Ring2", "Dye_Weapon", "Dye_Head", "Dye_Body", "Dye_Hands", "Dye_Legs", "Dye_Shoes", "Dye_Earrings", "Dye_Necklace", "Dye_Bracelets", "Dye_Ring1", "Dye_Ring2" };
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
        private Item _Dye_Weapon_selectedItem;
        private Item _Dye_Head_selectedItem;
        private Item _Dye_Body_selectedItem;
        private Item _Dye_Hands_selectedItem;
        private Item _Dye_Legs_selectedItem;
        private Item _Dye_Shoes_selectedItem;
        private Item _Dye_Earrings_selectedItem;
        private Item _Dye_Necklace_selectedItem;
        private Item _Dye_Bracelets_selectedItem;
        private Item _Dye_Ring1_selectedItem;
        private Item _Dye_Ring2_selectedItem;

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
        public ObservableCollection<Item> Dye_Weapon_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Head_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Body_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Hands_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Legs_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Shoes_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Earrings_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Necklace_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Bracelets_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Ring1_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Ring2_Results { get; } = new ObservableCollection<Item>();

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            Weapon_Filtered.ItemsSource = Weapon_Results;
            Head_Filtered.ItemsSource = Head_Results;
            Body_Filtered.ItemsSource = Body_Results;
            Hands_Filtered.ItemsSource = Hands_Results;
            Legs_Filtered.ItemsSource = Legs_Results;
            Shoes_Filtered.ItemsSource = Shoes_Results;
            Earrings_Filtered.ItemsSource = Earrings_Results;
            Necklace_Filtered.ItemsSource = Necklace_Results;
            Bracelets_Filtered.ItemsSource = Bracelets_Results;
            Ring1_Filtered.ItemsSource = Ring1_Results;
            Ring2_Filtered.ItemsSource = Ring2_Results;
            Dye_Weapon_Filtered.ItemsSource = Dye_Weapon_Results;
            Dye_Head_Filtered.ItemsSource = Dye_Head_Results;
            Dye_Body_Filtered.ItemsSource = Dye_Body_Results;
            Dye_Hands_Filtered.ItemsSource = Dye_Hands_Results;
            Dye_Legs_Filtered.ItemsSource = Dye_Legs_Results;
            Dye_Shoes_Filtered.ItemsSource = Dye_Shoes_Results;
            Dye_Earrings_Filtered.ItemsSource = Dye_Earrings_Results;
            Dye_Necklace_Filtered.ItemsSource = Dye_Necklace_Results;
            Dye_Bracelets_Filtered.ItemsSource = Dye_Bracelets_Results;
            Dye_Ring1_Filtered.ItemsSource = Dye_Ring1_Results;
            Dye_Ring2_Filtered.ItemsSource = Dye_Ring2_Results;
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

        #region Dye_Weapon
        private async void Dye_Weapon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                e.Handled = true;
                await SearchInfos(Dye_Weapon_imgSelectedIcon, Dye_Weapon_txtSelectedName, Dye_Weapon_selectedResultPanel, Dye_Weapon, Dye_Weapon_Popup, Dye_Weapon_Filtered, _Dye_Weapon_selectedItem);
            }
        }

        private void Dye_Weapon_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dye_Weapon_Filtered.SelectedItem != null)
            {
                _Dye_Weapon_selectedItem = (Item)Dye_Weapon_Filtered.SelectedItem;
                UpdateSelectedResultUI(Dye_Weapon_imgSelectedIcon, Dye_Weapon_txtSelectedName, Dye_Weapon_selectedResultPanel, Dye_Weapon, Dye_Weapon_Popup, _Dye_Weapon_selectedItem);

                Dye_Weapon_Popup.IsOpen = false;
            }
        }

        private void Dye_Weapon_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Dye_Weapon_selectedItem = null;
            UpdateSelectedResultUI(Dye_Weapon_imgSelectedIcon, Dye_Weapon_txtSelectedName, Dye_Weapon_selectedResultPanel, Dye_Weapon, Dye_Weapon_Popup, _Dye_Weapon_selectedItem);
        }
        #endregion

        #region Dye_Head
        private async void Dye_Head_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Dye_Head_imgSelectedIcon, Dye_Head_txtSelectedName, Dye_Head_selectedResultPanel, Dye_Head, Dye_Head_Popup, Dye_Head_Filtered, _Dye_Head_selectedItem);
            }
        }

        private void Dye_Head_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dye_Head_Filtered.SelectedItem != null)
            {
                _Dye_Head_selectedItem = (Item)Dye_Head_Filtered.SelectedItem;
                UpdateSelectedResultUI(Dye_Head_imgSelectedIcon, Dye_Head_txtSelectedName, Dye_Head_selectedResultPanel, Dye_Head, Dye_Head_Popup, _Dye_Head_selectedItem);

                Dye_Head_Popup.IsOpen = false;
            }
        }

        private void Dye_Head_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Dye_Head_selectedItem = null;
            UpdateSelectedResultUI(Dye_Head_imgSelectedIcon, Dye_Head_txtSelectedName, Dye_Head_selectedResultPanel, Dye_Head, Dye_Head_Popup, _Dye_Head_selectedItem);
        }
        #endregion

        #region Dye_Body
        private async void Dye_Body_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Dye_Body_imgSelectedIcon, Dye_Body_txtSelectedName, Dye_Body_selectedResultPanel, Dye_Body, Dye_Body_Popup, Dye_Body_Filtered, _Dye_Body_selectedItem);
            }
        }

        private void Dye_Body_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dye_Body_Filtered.SelectedItem != null)
            {
                _Dye_Body_selectedItem = (Item)Dye_Body_Filtered.SelectedItem;
                UpdateSelectedResultUI(Dye_Body_imgSelectedIcon, Dye_Body_txtSelectedName, Dye_Body_selectedResultPanel, Dye_Body, Dye_Body_Popup, _Dye_Body_selectedItem);

                Dye_Body_Popup.IsOpen = false;
            }
        }

        private void Dye_Body_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Dye_Body_selectedItem = null;
            UpdateSelectedResultUI(Dye_Body_imgSelectedIcon, Dye_Body_txtSelectedName, Dye_Body_selectedResultPanel, Dye_Body, Dye_Body_Popup, _Dye_Body_selectedItem);
        }
        #endregion

        #region Dye_Hands
        private async void Dye_Hands_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Dye_Hands_imgSelectedIcon, Dye_Hands_txtSelectedName, Dye_Hands_selectedResultPanel, Dye_Hands, Dye_Hands_Popup, Dye_Hands_Filtered, _Dye_Hands_selectedItem);
            }
        }

        private void Dye_Hands_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dye_Hands_Filtered.SelectedItem != null)
            {
                _Dye_Hands_selectedItem = (Item)Dye_Hands_Filtered.SelectedItem;
                UpdateSelectedResultUI(Dye_Hands_imgSelectedIcon, Dye_Hands_txtSelectedName, Dye_Hands_selectedResultPanel, Dye_Hands, Dye_Hands_Popup, _Dye_Hands_selectedItem);

                Dye_Hands_Popup.IsOpen = false;
            }
        }

        private void Dye_Hands_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Dye_Hands_selectedItem = null;
            UpdateSelectedResultUI(Dye_Hands_imgSelectedIcon, Dye_Hands_txtSelectedName, Dye_Hands_selectedResultPanel, Dye_Hands, Dye_Hands_Popup, _Dye_Hands_selectedItem);
        }
        #endregion

        #region Dye_Legs
        private async void Dye_Legs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Dye_Legs_imgSelectedIcon, Dye_Legs_txtSelectedName, Dye_Legs_selectedResultPanel, Dye_Legs, Dye_Legs_Popup, Dye_Legs_Filtered, _Dye_Legs_selectedItem);
            }
        }

        private void Dye_Legs_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dye_Legs_Filtered.SelectedItem != null)
            {
                _Dye_Legs_selectedItem = (Item)Dye_Legs_Filtered.SelectedItem;
                UpdateSelectedResultUI(Dye_Legs_imgSelectedIcon, Dye_Legs_txtSelectedName, Dye_Legs_selectedResultPanel, Dye_Legs, Dye_Legs_Popup, _Dye_Legs_selectedItem);

                Dye_Legs_Popup.IsOpen = false;
            }
        }

        private void Dye_Legs_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Dye_Legs_selectedItem = null;
            UpdateSelectedResultUI(Dye_Legs_imgSelectedIcon, Dye_Legs_txtSelectedName, Dye_Legs_selectedResultPanel, Dye_Legs, Dye_Legs_Popup, _Dye_Legs_selectedItem);
        }
        #endregion

        #region Dye_Shoes
        private async void Dye_Shoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Dye_Shoes_imgSelectedIcon, Dye_Shoes_txtSelectedName, Dye_Shoes_selectedResultPanel, Dye_Shoes, Dye_Shoes_Popup, Dye_Shoes_Filtered, _Dye_Shoes_selectedItem);
            }
        }

        private void Dye_Shoes_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dye_Shoes_Filtered.SelectedItem != null)
            {
                _Dye_Shoes_selectedItem = (Item)Dye_Shoes_Filtered.SelectedItem;
                UpdateSelectedResultUI(Dye_Shoes_imgSelectedIcon, Dye_Shoes_txtSelectedName, Dye_Shoes_selectedResultPanel, Dye_Shoes, Dye_Shoes_Popup, _Dye_Shoes_selectedItem);

                Dye_Shoes_Popup.IsOpen = false;
            }
        }

        private void Dye_Shoes_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Dye_Shoes_selectedItem = null;
            UpdateSelectedResultUI(Dye_Shoes_imgSelectedIcon, Dye_Shoes_txtSelectedName, Dye_Shoes_selectedResultPanel, Dye_Shoes, Dye_Shoes_Popup, _Dye_Shoes_selectedItem);
        }
        #endregion

        #region Dye_Earrings
        private async void Dye_Earrings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Dye_Earrings_imgSelectedIcon, Dye_Earrings_txtSelectedName, Dye_Earrings_selectedResultPanel, Dye_Earrings, Dye_Earrings_Popup, Dye_Earrings_Filtered, _Dye_Earrings_selectedItem);
            }
        }

        private void Dye_Earrings_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dye_Earrings_Filtered.SelectedItem != null)
            {
                _Dye_Earrings_selectedItem = (Item)Dye_Earrings_Filtered.SelectedItem;
                UpdateSelectedResultUI(Dye_Earrings_imgSelectedIcon, Dye_Earrings_txtSelectedName, Dye_Earrings_selectedResultPanel, Dye_Earrings, Dye_Earrings_Popup, _Dye_Earrings_selectedItem);

                Dye_Earrings_Popup.IsOpen = false;
            }
        }

        private void Dye_Earrings_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Dye_Earrings_selectedItem = null;
            UpdateSelectedResultUI(Dye_Earrings_imgSelectedIcon, Dye_Earrings_txtSelectedName, Dye_Earrings_selectedResultPanel, Dye_Earrings, Dye_Earrings_Popup, _Dye_Earrings_selectedItem);
        }
        #endregion

        #region Dye_Necklace
        private async void Dye_Necklace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Dye_Necklace_imgSelectedIcon, Dye_Necklace_txtSelectedName, Dye_Necklace_selectedResultPanel, Dye_Necklace, Dye_Necklace_Popup, Dye_Necklace_Filtered, _Dye_Necklace_selectedItem);
            }
        }

        private void Dye_Necklace_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dye_Necklace_Filtered.SelectedItem != null)
            {
                _Dye_Necklace_selectedItem = (Item)Dye_Necklace_Filtered.SelectedItem;
                UpdateSelectedResultUI(Dye_Necklace_imgSelectedIcon, Dye_Necklace_txtSelectedName, Dye_Necklace_selectedResultPanel, Dye_Necklace, Dye_Necklace_Popup, _Dye_Necklace_selectedItem);

                Dye_Necklace_Popup.IsOpen = false;
            }
        }

        private void Dye_Necklace_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Dye_Necklace_selectedItem = null;
            UpdateSelectedResultUI(Dye_Necklace_imgSelectedIcon, Dye_Necklace_txtSelectedName, Dye_Necklace_selectedResultPanel, Dye_Necklace, Dye_Necklace_Popup, _Dye_Necklace_selectedItem);
        }
        #endregion

        #region Dye_Bracelets
        private async void Dye_Bracelets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Dye_Bracelets_imgSelectedIcon, Dye_Bracelets_txtSelectedName, Dye_Bracelets_selectedResultPanel, Dye_Bracelets, Dye_Bracelets_Popup, Dye_Bracelets_Filtered, _Dye_Bracelets_selectedItem);
            }
        }

        private void Dye_Bracelets_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dye_Bracelets_Filtered.SelectedItem != null)
            {
                _Dye_Bracelets_selectedItem = (Item)Dye_Bracelets_Filtered.SelectedItem;
                UpdateSelectedResultUI(Dye_Bracelets_imgSelectedIcon, Dye_Bracelets_txtSelectedName, Dye_Bracelets_selectedResultPanel, Dye_Bracelets, Dye_Bracelets_Popup, _Dye_Bracelets_selectedItem);

                Dye_Bracelets_Popup.IsOpen = false;
            }
        }

        private void Dye_Bracelets_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Dye_Bracelets_selectedItem = null;
            UpdateSelectedResultUI(Dye_Bracelets_imgSelectedIcon, Dye_Bracelets_txtSelectedName, Dye_Bracelets_selectedResultPanel, Dye_Bracelets, Dye_Bracelets_Popup, _Dye_Bracelets_selectedItem);
        }
        #endregion

        #region Dye_Ring1
        private async void Dye_Ring1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Dye_Ring1_imgSelectedIcon, Dye_Ring1_txtSelectedName, Dye_Ring1_selectedResultPanel, Dye_Ring1, Dye_Ring1_Popup, Dye_Ring1_Filtered, _Dye_Ring1_selectedItem);
            }
        }

        private void Dye_Ring1_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dye_Ring1_Filtered.SelectedItem != null)
            {
                _Dye_Ring1_selectedItem = (Item)Dye_Ring1_Filtered.SelectedItem;
                UpdateSelectedResultUI(Dye_Ring1_imgSelectedIcon, Dye_Ring1_txtSelectedName, Dye_Ring1_selectedResultPanel, Dye_Ring1, Dye_Ring1_Popup, _Dye_Ring1_selectedItem);

                Dye_Ring1_Popup.IsOpen = false;
            }
        }

        private void Dye_Ring1_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Dye_Ring1_selectedItem = null;
            UpdateSelectedResultUI(Dye_Ring1_imgSelectedIcon, Dye_Ring1_txtSelectedName, Dye_Ring1_selectedResultPanel, Dye_Ring1, Dye_Ring1_Popup, _Dye_Ring1_selectedItem);
        }
        #endregion

        #region Dye_Ring2
        private async void Dye_Ring2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Dye_Ring2_imgSelectedIcon, Dye_Ring2_txtSelectedName, Dye_Ring2_selectedResultPanel, Dye_Ring2, Dye_Ring2_Popup, Dye_Ring2_Filtered, _Dye_Ring2_selectedItem);
            }
        }

        private void Dye_Ring2_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dye_Ring2_Filtered.SelectedItem != null)
            {
                _Dye_Ring2_selectedItem = (Item)Dye_Ring2_Filtered.SelectedItem;
                UpdateSelectedResultUI(Dye_Ring2_imgSelectedIcon, Dye_Ring2_txtSelectedName, Dye_Ring2_selectedResultPanel, Dye_Ring2, Dye_Ring2_Popup, _Dye_Ring2_selectedItem);

                Dye_Ring2_Popup.IsOpen = false;
            }
        }

        private void Dye_Ring2_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Dye_Ring2_selectedItem = null;
            UpdateSelectedResultUI(Dye_Ring2_imgSelectedIcon, Dye_Ring2_txtSelectedName, Dye_Ring2_selectedResultPanel, Dye_Ring2, Dye_Ring2_Popup, _Dye_Ring2_selectedItem);
        }
        #endregion

        #region Equipments and Dye
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
                case "Dye_Weapon":
                    Dye_Weapon_Results.Clear();
                    break;
                case "Dye_Head":
                    Dye_Head_Results.Clear();
                    break;
                case "Dye_Body":
                    Dye_Body_Results.Clear();
                    break;
                case "Dye_Hands":
                    Dye_Hands_Results.Clear();
                    break;
                case "Dye_Legs":
                    Dye_Legs_Results.Clear();
                    break;
                case "Dye_Shoes":
                    Dye_Shoes_Results.Clear();
                    break;
                case "Dye_Earrings":
                    Dye_Earrings_Results.Clear();
                    break;
                case "Dye_Necklace":
                    Dye_Necklace_Results.Clear();
                    break;
                case "Dye_Bracelets":
                    Dye_Bracelets_Results.Clear();
                    break;
                case "Dye_Ring1":
                    Dye_Ring1_Results.Clear();
                    break;
                case "Dye_Ring2":
                    Dye_Ring2_Results.Clear();
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
                case "Dye_Weapon":
                    Dye_Weapon_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Head":
                    Dye_Head_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Body":
                    Dye_Body_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Hands":
                    Dye_Hands_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Legs":
                    Dye_Legs_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Shoes":
                    Dye_Shoes_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Earrings":
                    Dye_Earrings_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Necklace":
                    Dye_Necklace_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Bracelets":
                    Dye_Bracelets_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Ring1":
                    Dye_Ring1_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = BreakNameIntoMultipleLines(item.Name),
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Ring2":
                    Dye_Ring2_Results.Add(new Item
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
                case "Dye_Weapon":
                    filteredItems = Dye_Weapon_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Weapon_Results;
                    break;
                case "Dye_Head":
                    filteredItems = Dye_Head_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Head_Results;
                    break;
                case "Dye_Body":
                    filteredItems = Dye_Body_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Body_Results;
                    break;
                case "Dye_Hands":
                    filteredItems = Dye_Hands_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Hands_Results;
                    break;
                case "Dye_Legs":
                    filteredItems = Dye_Legs_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Legs_Results;
                    break;
                case "Dye_Shoes":
                    filteredItems = Dye_Shoes_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Shoes_Results;
                    break;
                case "Dye_Earrings":
                    filteredItems = Dye_Earrings_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Earrings_Results;
                    break;
                case "Dye_Necklace":
                    filteredItems = Dye_Necklace_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Necklace_Results;
                    break;
                case "Dye_Bracelets":
                    filteredItems = Dye_Bracelets_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Bracelets_Results;
                    break;
                case "Dye_Ring1":
                    filteredItems = Dye_Ring1_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Ring1_Results;
                    break;
                case "Dye_Ring2":
                    filteredItems = Dye_Ring2_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Ring2_Results;
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
                case "Dye_Weapon":
                    filteredItems = Dye_Weapon_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Weapon_Results;
                    break;
                case "Dye_Head":
                    filteredItems = Dye_Head_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Head_Results;
                    break;
                case "Dye_Body":
                    filteredItems = Dye_Body_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Body_Results;
                    break;
                case "Dye_Hands":
                    filteredItems = Dye_Hands_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Hands_Results;
                    break;
                case "Dye_Legs":
                    filteredItems = Dye_Legs_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Legs_Results;
                    break;
                case "Dye_Shoes":
                    filteredItems = Dye_Shoes_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Shoes_Results;
                    break;
                case "Dye_Earrings":
                    filteredItems = Dye_Earrings_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Earrings_Results;
                    break;
                case "Dye_Necklace":
                    filteredItems = Dye_Necklace_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Necklace_Results;
                    break;
                case "Dye_Bracelets":
                    filteredItems = Dye_Bracelets_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Bracelets_Results;
                    break;
                case "Dye_Ring1":
                    filteredItems = Dye_Ring1_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Ring1_Results;
                    break;
                case "Dye_Ring2":
                    filteredItems = Dye_Ring2_Results.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
                    listView.ItemsSource = Dye_Ring2_Results;
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
            if (textBox != null)
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
            listName = await GetItemInfoDictionaryAsync(_Dye_Weapon_selectedItem, "Dye_Weapon", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Head_selectedItem, "Dye_Head", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Body_selectedItem, "Dye_Body", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Hands_selectedItem, "Dye_Hands", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Legs_selectedItem, "Dye_Legs", listName);
            listName = await GetItemInfoDictionaryAsync(_Dye_Shoes_selectedItem, "Dye_Shoes", listName);
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
