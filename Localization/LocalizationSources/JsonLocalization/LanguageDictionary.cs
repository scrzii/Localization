using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization.LocalizationSources.JsonLocalization
{
    public class LanguageDictionary
    {
        [JsonProperty("cultureName")]
        public string CultureName { get; set; }
        [JsonProperty("words")]
        public Dictionary<string, string> Strings { get; set; }
    }
}
