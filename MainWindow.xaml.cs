using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FFXIVFashionReport
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            Weapon_Filtered.ItemsSource = Weapon_Results;
            Head_Filtered.ItemsSource = Head_Results;
            Body_Filtered.ItemsSource = Body_Results;
            Hands_Filtered.ItemsSource = Hands_Results;
            Legs_Filtered.ItemsSource = Legs_Results;
            Feet_Filtered.ItemsSource = Feet_Results;
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
            Dye_Feet_Filtered.ItemsSource = Dye_Feet_Results;
            Dye_Earrings_Filtered.ItemsSource = Dye_Earrings_Results;
            Dye_Necklace_Filtered.ItemsSource = Dye_Necklace_Results;
            Dye_Bracelets_Filtered.ItemsSource = Dye_Bracelets_Results;
            Dye_Ring1_Filtered.ItemsSource = Dye_Ring1_Results;
            Dye_Ring2_Filtered.ItemsSource = Dye_Ring2_Results;
        }

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

        #region Feet
        private async void Feet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Feet_imgSelectedIcon, Feet_txtSelectedName, Feet_selectedResultPanel, Feet, Feet_Popup, Feet_Filtered, _Feet_selectedItem);
            }
        }

        private void Feet_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Feet_Filtered.SelectedItem != null)
            {
                _Feet_selectedItem = (Item)Feet_Filtered.SelectedItem;
                UpdateSelectedResultUI(Feet_imgSelectedIcon, Feet_txtSelectedName, Feet_selectedResultPanel, Feet, Feet_Popup, _Feet_selectedItem);

                Feet_Popup.IsOpen = false;
            }
        }

        private void Feet_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Feet_selectedItem = null;
            UpdateSelectedResultUI(Feet_imgSelectedIcon, Feet_txtSelectedName, Feet_selectedResultPanel, Feet, Feet_Popup, _Feet_selectedItem);
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

        #region Dye_Feet
        private async void Dye_Feet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == KeyInterop.KeyFromVirtualKey(13))
            {
                await SearchInfos(Dye_Feet_imgSelectedIcon, Dye_Feet_txtSelectedName, Dye_Feet_selectedResultPanel, Dye_Feet, Dye_Feet_Popup, Dye_Feet_Filtered, _Dye_Feet_selectedItem);
            }
        }

        private void Dye_Feet_Filtered_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Dye_Feet_Filtered.SelectedItem != null)
            {
                _Dye_Feet_selectedItem = (Item)Dye_Feet_Filtered.SelectedItem;
                UpdateSelectedResultUI(Dye_Feet_imgSelectedIcon, Dye_Feet_txtSelectedName, Dye_Feet_selectedResultPanel, Dye_Feet, Dye_Feet_Popup, _Dye_Feet_selectedItem);

                Dye_Feet_Popup.IsOpen = false;
            }
        }

        private void Dye_Feet_btnRemove_Click(object sender, RoutedEventArgs e)
        {
            _Dye_Feet_selectedItem = null;
            UpdateSelectedResultUI(Dye_Feet_imgSelectedIcon, Dye_Feet_txtSelectedName, Dye_Feet_selectedResultPanel, Dye_Feet, Dye_Feet_Popup, _Dye_Feet_selectedItem);
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
            ObservableCollection<Item> results = null;

            switch (textBox.Name)
            {
                case "Weapon": results = Weapon_Results; break;
                case "Head": results = Head_Results; break;
                case "Body": results = Body_Results; break;
                case "Hands": results = Hands_Results; break;
                case "Legs": results = Legs_Results; break;
                case "Feet": results = Feet_Results; break;
                case "Earrings": results = Earrings_Results; break;
                case "Necklace": results = Necklace_Results; break;
                case "Bracelets": results = Bracelets_Results; break;
                case "Ring1": results = Ring1_Results; break;
                case "Ring2": results = Ring2_Results; break;
                case "Dye_Weapon": results = Dye_Weapon_Results; break;
                case "Dye_Head": results = Dye_Head_Results; break;
                case "Dye_Body": results = Dye_Body_Results; break;
                case "Dye_Hands": results = Dye_Hands_Results; break;
                case "Dye_Legs": results = Dye_Legs_Results; break;
                case "Dye_Feet": results = Dye_Feet_Results; break;
                case "Dye_Earrings": results = Dye_Earrings_Results; break;
                case "Dye_Necklace": results = Dye_Necklace_Results; break;
                case "Dye_Bracelets": results = Dye_Bracelets_Results; break;
                case "Dye_Ring1": results = Dye_Ring1_Results; break;
                case "Dye_Ring2": results = Dye_Ring2_Results; break;
            }

            results?.Clear();
        }

        private void StoreItems(TextBox textBox, Item item)
        {
            switch (textBox.Name)
            {
                case "Weapon":
                    Weapon_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Head":
                    Head_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Body":
                    Body_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Hands":
                    Hands_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Legs":
                    Legs_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Feet":
                    Feet_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Earrings":
                    Earrings_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Necklace":
                    Necklace_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Bracelets":
                    Bracelets_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Ring1":
                    Ring1_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Ring2":
                    Ring2_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Weapon":
                    Dye_Weapon_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Head":
                    Dye_Head_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Body":
                    Dye_Body_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Hands":
                    Dye_Hands_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Legs":
                    Dye_Legs_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Feet":
                    Dye_Feet_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Earrings":
                    Dye_Earrings_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Necklace":
                    Dye_Necklace_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Bracelets":
                    Dye_Bracelets_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Ring1":
                    Dye_Ring1_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                case "Dye_Ring2":
                    Dye_Ring2_Results.Add(new Item
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Icon = item.Icon
                    });
                    break;
                default:
                    break;
            }
        }

        private List<Item> FiltedItems(TextBox textBox, ListView listView, string filterText)
        {
            ObservableCollection<Item> itemsCollection = GetItemsCollection(textBox.Name);

            if (itemsCollection != null)
            {
                listView.ItemsSource = itemsCollection;
                return itemsCollection.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
            }

            return new List<Item>();
        }

        private List<Item> ResultItems(TextBox textBox, ListView listView, string filterText)
        {
            ObservableCollection<Item> itemsCollection = GetItemsCollection(textBox.Name);

            if (itemsCollection != null)
            {
                listView.ItemsSource = itemsCollection;
                return itemsCollection.Where(item => item.Name.ToLower().Contains(filterText)).ToList();
            }

            return new List<Item>();
        }

        private ObservableCollection<Item> GetItemsCollection(string textBoxName)
        {
            // Use a dictionary to map textBoxName to the corresponding collection
            Dictionary<string, ObservableCollection<Item>> collections = new Dictionary<string, ObservableCollection<Item>>
            {
                { "Weapon", Weapon_Results },
                { "Head", Head_Results },
                { "Body", Body_Results },
                { "Hands", Hands_Results },
                { "Legs", Legs_Results },
                { "Feet", Feet_Results },
                { "Earrings", Earrings_Results },
                { "Necklace", Necklace_Results },
                { "Bracelets", Bracelets_Results },
                { "Ring1", Ring1_Results },
                { "Ring2", Ring2_Results },
                { "Dye_Weapon", Dye_Weapon_Results },
                { "Dye_Head", Dye_Head_Results },
                { "Dye_Body", Dye_Body_Results },
                { "Dye_Hands", Dye_Hands_Results },
                { "Dye_Legs", Dye_Legs_Results },
                { "Dye_Feet", Dye_Feet_Results },
                { "Dye_Earrings", Dye_Earrings_Results },
                { "Dye_Necklace", Dye_Necklace_Results },
                { "Dye_Bracelets", Dye_Bracelets_Results },
                { "Dye_Ring1", Dye_Ring1_Results },
                { "Dye_Ring2", Dye_Ring2_Results }
            };

            if (collections.TryGetValue(textBoxName, out var itemsCollection))
            {
                return itemsCollection;
            }

            return null;
        }
        #endregion

        
    }
}
