using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;

namespace FFXIVFashionReport
{
    public partial class MainWindow
    {
        private static readonly string Key = ConfigurationManager.AppSettings["Key"];

        private List<string> languageList = new List<string> { "Fr", "De", "Ja", "En" };
        private List<string> EquipmentList = new List<string> { "Weapon", "Head", "Body", "Hands", "Legs", "Feet", "Earrings", "Necklace", "Bracelets", "Ring1", "Ring2", "Dye_Weapon", "Dye_Head", "Dye_Body", "Dye_Hands", "Dye_Legs", "Dye_Feet", "Dye_Earrings", "Dye_Necklace", "Dye_Bracelets", "Dye_Ring1", "Dye_Ring2" };
        private List<int> WeaponList = new List<int>() { 9, 10, 11, 12, 13, 14, 15, 16, 18, 73, 76, 77, 78, 83, 84, 85, 86, 87, 88, 89 };
        private Dictionary<string, int?> EquipementDictionary = new Dictionary<string, int?>() { { "Head", 31 }, { "Body", 33 }, { "Hands", 36 }, { "Legs", 35 }, { "Feet", 37 }, { "Earrings", 40 }, { "Necklace", 39 }, { "Bracelets", 41 }, { "Ring1", 42 }, { "Ring2", 42 } };

        private HttpClient _httpClient;
        private const string ApiBaseUrl = "https://xivapi.com/search";
        private const int MillisecondsDelay = 1000;
        private const int SaveMillisecondsDelay = 2000;
        private const string linkBaseUrl = "https://ffxivteamcraft.com/db/fr/item/";
    }
}
