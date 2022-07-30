using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization
{
    public class LocalizationManager : ILocalizationManager
    {
        private List<ILocalizationSource> Sources { get; set; }

        public LocalizationManager()
        {
            Sources = new List<ILocalizationSource>();
        }

        public LocalizationManager(ILocalizationSource source)
        {
            Sources = new List<ILocalizationSource> { source };
        }

        public LocalizationManager(IEnumerable<ILocalizationSource> sources)
        {
            Sources = sources.ToList();
        }

        public string GetString(string sourceName, CultureInfo culture)
        {
            var bestSource = Sources.FirstOrDefault(_ => _.GetString(sourceName, culture) != null);
            if (bestSource == null)
            {
                throw new Exception("Строка не найдена ни в одном источнике");
            }

            return bestSource.GetString(sourceName, culture);
        }

        public void RegisterSource(ILocalizationSource source)
        {
            Sources.Add(source);
        }
    }
}
