using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVFashionReport
{
    public partial class MainWindow
    {
        public ObservableCollection<Item> Weapon_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Head_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Body_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Hands_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Legs_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Feet_Results { get; } = new ObservableCollection<Item>();
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
        public ObservableCollection<Item> Dye_Feet_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Earrings_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Necklace_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Bracelets_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Ring1_Results { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> Dye_Ring2_Results { get; } = new ObservableCollection<Item>();
    }
}
