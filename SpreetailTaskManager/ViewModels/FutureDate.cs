using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SpreetailTaskManager.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            //var isValid = true;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "MM/dd/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            //return isValid;

            return (isValid && dateTime > DateTime.Now);
        }
    }
}