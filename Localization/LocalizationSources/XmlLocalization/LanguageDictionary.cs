using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization.LocalizationSources.XmlLocalization
{
    public class LanguageDictionary
    {
        public string CultureName { get; set; }
        public List<WordPair> Words { get; set; }
    }
}
