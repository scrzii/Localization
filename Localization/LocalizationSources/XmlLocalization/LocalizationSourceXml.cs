using Localization.LocalizationSources.XmlLocalization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Localization.LocalizationSources
{
    public class LocalizationSourceXml : ILocalizationSource
    {
        private LanguageDictionary[] Sources { get; set; }

        public LocalizationSourceXml(string xmlPath)
        {
            using (var stream = new FileStream(xmlPath, FileMode.Open))
            {
                var xml = new XmlSerializer(typeof(LanguageDictionary[]));
                Sources = xml.Deserialize(stream) as LanguageDictionary[];
            }
        }

        public string GetString(string sourceName, CultureInfo culture)
        {
            // Это можно оптимизировать, если конвертировать массив пар в словарь
            var dictionary = Sources.FirstOrDefault(_ => _.CultureName == culture.Name);
            if (dictionary == null)
            {
                return null;
            }
            return dictionary.Words.FirstOrDefault(_ => _.WordKey == sourceName)?.WordValue;
        }
    }
}
