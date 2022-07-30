using Localization.LocalizationSources.JsonLocalization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization.LocalizationSources
{
    public class LocalizationSourceJson : ILocalizationSource
    {
        private LanguageDictionary[] Sources { get; set; }

        public LocalizationSourceJson(string jsonPath)
        {
            Sources = JsonConvert.DeserializeObject<LanguageDictionary[]>(File.ReadAllText(jsonPath));
        }

        public string GetString(string sourceName, CultureInfo culture)
        {
            var dictionary = Sources.FirstOrDefault(_ => _.CultureName == culture.Name);
            if (dictionary == null || !dictionary.Strings.ContainsKey(sourceName))
            {
                return null;
            }
            return dictionary.Strings[sourceName];
        }
    }
}
