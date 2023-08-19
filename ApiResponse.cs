using Newtonsoft.Json;
using System.Collections.Generic;

namespace FFXIVFashionReport
{
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

        public ItemSearchCategory itemSearchCategory { get; set; }
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

    public class ItemSearchCategory
    {
        [JsonProperty("ID")]
        public int? ID { get; set; }
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
}
