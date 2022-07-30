using Localization;
using Localization.LocalizationSources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var locale = new LocalizationManager();
            locale.RegisterSource(new LocalizationSourceJson("./Dictionary.json"));
            locale.RegisterSource(new LocalizationSourceXml("./Dictionary.xml"));

            Console.Write("Enter your word: ");
            var word = Console.ReadLine();
            Console.Write("Enter your culture: ");
            var cultureName = Console.ReadLine();

            var culture = CultureInfo.GetCultureInfo(cultureName);
            Console.WriteLine(locale.GetString(word, culture));

            Console.ReadKey();
        }
    }
}
