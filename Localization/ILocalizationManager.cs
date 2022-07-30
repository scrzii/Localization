using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization
{
    public interface ILocalizationManager
    {
        string GetString(string sourceName, CultureInfo culture);
        void RegisterSource(ILocalizationSource source);
    }
}
