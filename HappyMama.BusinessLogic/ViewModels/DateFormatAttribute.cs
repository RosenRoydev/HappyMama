using System.ComponentModel.DataAnnotations;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;

namespace HappyMama.BusinessLogic.ViewModels
{
    public class DateFormatAttribute : ValidationAttribute
    {
        private readonly string dateFormat;

        public DateFormatAttribute(string _dateFormat)
        {
            dateFormat = _dateFormat;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is DateTime dateTime)
            {
                if (DateTime.TryParseExact(dateTime.ToString(),
                    dateFormat,null,
                    System.Globalization.DateTimeStyles.None,
                    out _))
                {
                   return ValidationResult.Success;
                }

                else
                {
                    return new ValidationResult(NotCorrectDateFormat);
                }
            }

            return new ValidationResult(InvalidValueType);
        }
    }
}
