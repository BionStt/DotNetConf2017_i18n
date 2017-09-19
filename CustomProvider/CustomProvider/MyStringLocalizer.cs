namespace CustomLocalizer
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Microsoft.Extensions.Localization;

    public class MyStringLocalizer : IStringLocalizer
    {
        private readonly CultureInfo _culture;

        private readonly List<MyStringData> _stringData; 
               
        public MyStringLocalizer()
        {
            _stringData = new List<MyStringData>();
            
            InitializeLocalizedStrings(_stringData);
        }
        
        public MyStringLocalizer(CultureInfo culture) : this()
        {
            _culture = culture;
        }
        
        public LocalizedString this[string name]
        {
            get
            {
                var culture = _culture ?? CultureInfo.CurrentUICulture;
                var translation = _stringData.FirstOrDefault(x => x.CultureName == culture.Name && x.Name == name)?.Value;
                
                return new LocalizedString(name, translation ?? name, translation != null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var culture = _culture ?? CultureInfo.CurrentUICulture;
                var translation = _stringData.FirstOrDefault(x => x.CultureName == culture.Name && x.Name == name)?.Value;

                if (translation != null)
                {
                    translation = string.Format(translation, arguments);
                }
                
                return new LocalizedString(name, translation ?? name, translation != null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _stringData.Select(x => new LocalizedString(x.Name, x.Value, true)).ToList();
        }
        
        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new MyStringLocalizer(culture);
        }
        
        private void InitializeLocalizedStrings(List<MyStringData> localizedStrings)
        {
            localizedStrings.Clear();

            localizedStrings.Add(new MyStringData("en-US", "Hello", "Hello"));
            localizedStrings.Add(new MyStringData("en-US", "Goodbye", "Goodbye"));
            localizedStrings.Add(new MyStringData("en-US", "CurrentDate", "Current Date"));
            localizedStrings.Add(new MyStringData("en-US", "FormattedNumber", "Formatted Number"));
            localizedStrings.Add(new MyStringData("en-US", "CurrencyValue", "Currency Value"));
            localizedStrings.Add(new MyStringData("en-US", "DetectedCulture", "Detected Culture"));
            localizedStrings.Add(new MyStringData("en-US", "DetectedUICulture", "Detected UI Culture"));

            localizedStrings.Add(new MyStringData("it-IT", "Hello", "Ciao"));
            localizedStrings.Add(new MyStringData("it-IT", "Goodbye", "Arrivederci"));
            localizedStrings.Add(new MyStringData("it-IT", "CurrentDate", "Data Corrente"));
            localizedStrings.Add(new MyStringData("it-IT", "FormattedNumber", "Numero Formattato"));
            localizedStrings.Add(new MyStringData("it-IT", "CurrencyValue", "Valore di Valuta"));
            localizedStrings.Add(new MyStringData("it-IT", "DetectedCulture", "Cultura rivelata"));
            localizedStrings.Add(new MyStringData("it-IT", "DetectedUICulture", "Cultura UI rivelata"));

            localizedStrings.Add(new MyStringData("ja-JP", "Hello", "こんにちは"));
            localizedStrings.Add(new MyStringData("ja-JP", "Goodbye", "さようなら"));
            localizedStrings.Add(new MyStringData("ja-JP", "CurrentDate", "現在の日付"));
            localizedStrings.Add(new MyStringData("ja-JP", "FormattedNumber", "フォーマットされた数値"));
            localizedStrings.Add(new MyStringData("ja-JP", "CurrencyValue", "通貨の値"));
            localizedStrings.Add(new MyStringData("ja-JP", "DetectedCulture", "検出された文化"));
            localizedStrings.Add(new MyStringData("ja-JP", "DetectedUICulture", "検出されたUI文化"));

            localizedStrings.Add(new MyStringData("nl-NL", "Hello", "Hallo"));
            localizedStrings.Add(new MyStringData("nl-NL", "Goodbye", "Tot ziens"));
            localizedStrings.Add(new MyStringData("nl-NL", "CurrentDate", "Huidige Datum"));
            localizedStrings.Add(new MyStringData("nl-NL", "FormattedNumber", "Opgemaakte Nummer"));
            localizedStrings.Add(new MyStringData("nl-NL", "CurrencyValue", "Valutawaarde"));
            localizedStrings.Add(new MyStringData("nl-NL", "DetectedCulture", "Ontdekte Cultuur"));
            localizedStrings.Add(new MyStringData("nl-NL", "DetectedUICulture", "Ontdekte UI-cultuur"));

            localizedStrings.Add(new MyStringData("ru-RU", "Hello", "Привет"));
            localizedStrings.Add(new MyStringData("ru-RU", "Goodbye", "До свидания"));
            localizedStrings.Add(new MyStringData("ru-RU", "CurrentDate", "Текущая дата"));
            localizedStrings.Add(new MyStringData("ru-RU", "FormattedNumber", "Отформатированный номер"));
            localizedStrings.Add(new MyStringData("ru-RU", "CurrencyValue", "Значение валюты"));
            localizedStrings.Add(new MyStringData("ru-RU", "DetectedCulture", "Обнаруженная культура"));
            localizedStrings.Add(new MyStringData("ru-RU", "DetectedUICulture", "Обнаружен UI Культура"));
        }
        
        private class MyStringData
        {
            public MyStringData(string cultureName, string name, string value)
            {
                CultureName = cultureName;
                Name = name;
                Value = value;
            }
        
            public string CultureName { get; private set; }
            
            public string Name {get; private set; }

            public string Value {get; private set; }
        }
    }
}