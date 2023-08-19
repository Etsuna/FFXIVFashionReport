using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVFashionReport
{
    public partial class MainWindow
    {
        private static string Key = "cd6f068c506d418fa1699cc4e86772ccc05bdc574a664f2ba5db3db179f87a7f";

        private List<string> languageList = new List<string> { "Fr", "De", "Ja", "En" };
        private List<string> EquipmentList = new List<string> { "Weapon", "Head", "Body", "Hands", "Legs", "Feet", "Earrings", "Necklace", "Bracelets", "Ring1", "Ring2", "Dye_Weapon", "Dye_Head", "Dye_Body", "Dye_Hands", "Dye_Legs", "Dye_Feet", "Dye_Earrings", "Dye_Necklace", "Dye_Bracelets", "Dye_Ring1", "Dye_Ring2" };
        private List<int> WeaponList = new List<int>() { 9, 10, 11, 12, 13, 14, 15, 16, 18, 73, 76, 77, 78, 83, 84, 85, 86, 87, 88, 89 };
        private Dictionary<string, int?> EquipementDictionary = new Dictionary<string, int?>() { { "Head", 31 }, { "Body", 33 }, { "Hands", 36 }, { "Legs", 35 }, { "Feet", 37 }, { "Earrings", 40 }, { "Necklace", 39 }, { "Bracelets", 41 }, { "Ring1", 42 }, { "Ring2", 42 } };

        private HttpClient _httpClient;
        private const string ApiBaseUrl = "https://xivapi.com/search";
        private const int MillisecondsDelay = 1000;
        private const int SaveMillisecondsDelay = 2000;
    }
}
