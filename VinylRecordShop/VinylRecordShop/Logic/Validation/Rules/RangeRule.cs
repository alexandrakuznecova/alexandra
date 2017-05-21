using System;
using System.Globalization;
using System.Windows.Controls;

namespace VinylRecordShop.Logic.Validation.Rules
{
    class RangeRule : ValidationRule
    {
        private int? _min;
        private int? _max;

        public int? Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int? Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int intValue = 0;

            try
            {
                string stringValue = (string) value;
                if (stringValue.Length > 0)
                    intValue = Int32.Parse(stringValue);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Недопустимый символ или " + e.Message);
            }

            if (intValue < Min || intValue > Max)
            {
                return new ValidationResult(false,
                    "Пожалуйста введите число в диапозоне: " + Min + " - " + Max + ".");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
