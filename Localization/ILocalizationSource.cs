using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localization
{
    public interface ILocalizationSource
    {
        string GetString(string sourceName, CultureInfo culture);
    }
}
