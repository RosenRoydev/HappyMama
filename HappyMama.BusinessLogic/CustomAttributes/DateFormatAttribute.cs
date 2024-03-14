using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;

namespace HappyMama.BusinessLogic.CustomAttributes
{
    public class DateFormatAttribute : ValidationAttribute
    {
        

        public override bool IsValid(object value)
        {
			
			DateTime dateTime;

			var isValid = DateTime.TryParseExact(Convert.ToString(value),
				"dd.MM.yyyy HH:mm:ss",
				CultureInfo.CurrentCulture,
				DateTimeStyles.None,
				out dateTime);

			return isValid;


		}
    }
}
