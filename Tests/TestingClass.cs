using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Localization;
using Localization.LocalizationSources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestingClass
    {
        [TestMethod]
        public void WordsTesting_English_WordExists()
        {
            var locale = new LocalizationManager();
            locale.RegisterSource(new LocalizationSourceJson("./Dictionary.json"));
            locale.RegisterSource(new LocalizationSourceXml("./Dictionary.xml"));
            var culture = CultureInfo.GetCultureInfo("en-US");
            var words = new Dictionary<string, string>
            {
                ["cat"] = "cat",
                ["dog"] = "dog",
                ["snake"] = "snake",
                ["dolphin"] = "dolphin"
            };
            foreach (var wordPair in words)
            {
                var wordKey = wordPair.Key;
                var expectedTranslation = wordPair.Value;
                var realTranslation = locale.GetString(wordKey, culture);
                Assert.AreEqual(expectedTranslation, realTranslation);
            }
        }
        [TestMethod]
        public void WordsTesting_Russian_WordExists()
        {
            var locale = new LocalizationManager();
            locale.RegisterSource(new LocalizationSourceJson("./Dictionary.json"));
            locale.RegisterSource(new LocalizationSourceXml("./Dictionary.xml"));
            var culture = CultureInfo.GetCultureInfo("ru-RU");
            var words = new Dictionary<string, string>
            {
                ["cat"] = "кошка",
                ["dog"] = "собака",
                ["snake"] = "змея",
                ["dolphin"] = "дельфин"
            };
            foreach (var wordPair in words)
            {
                var wordKey = wordPair.Key;
                var expectedTranslation = wordPair.Value;
                var realTranslation = locale.GetString(wordKey, culture);
                Assert.AreEqual(expectedTranslation, realTranslation);
            }
        }
        [TestMethod]
        public void WordsTesting_Italian_WordExists()
        {
            var locale = new LocalizationManager();
            locale.RegisterSource(new LocalizationSourceJson("./Dictionary.json"));
            locale.RegisterSource(new LocalizationSourceXml("./Dictionary.xml"));
            var culture = CultureInfo.GetCultureInfo("it-IT");
            var words = new Dictionary<string, string>
            {
                ["cat"] = "gatto",
                ["dog"] = "cane",
                ["snake"] = "serpente",
                ["dolphin"] = "delfino"
            };
            foreach (var wordPair in words)
            {
                var wordKey = wordPair.Key;
                var expectedTranslation = wordPair.Value;
                var realTranslation = locale.GetString(wordKey, culture);
                Assert.AreEqual(expectedTranslation, realTranslation);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WordsTesting_Russian_WordNotExists()
        {
            var locale = new LocalizationManager();
            locale.RegisterSource(new LocalizationSourceJson("./Dictionary.json"));
            locale.RegisterSource(new LocalizationSourceXml("./Dictionary.xml"));
            var culture = CultureInfo.GetCultureInfo("ru-RU");
            var word = "貓";
            locale.GetString(word, culture);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WordsTesting_Italian_WordNotExists()
        {
            var locale = new LocalizationManager();
            locale.RegisterSource(new LocalizationSourceJson("./Dictionary.json"));
            locale.RegisterSource(new LocalizationSourceXml("./Dictionary.xml"));
            var culture = CultureInfo.GetCultureInfo("ru-RU");
            var word = "cane";
            locale.GetString(word, culture);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WordsTesting_English_WordNotExists()
        {
            var locale = new LocalizationManager();
            locale.RegisterSource(new LocalizationSourceJson("./Dictionary.json"));
            locale.RegisterSource(new LocalizationSourceXml("./Dictionary.xml"));
            var culture = CultureInfo.GetCultureInfo("ru-RU");
            var word = "кошка";
            locale.GetString(word, culture);
        }
    }
}
