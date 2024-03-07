using System.ComponentModel.DataAnnotations;

namespace HappyMama.BusinessLogic.Constants
{
    public static class ErrorMessagesConstants
    {
        public const string RequiredLength = "The {0} field must be between {2} and {1} characters";

        public const string RequiredField = "The field {0} is required";

        public const string NeededAmountRestrict = "The field {0} must be between {1} and {2} BGN";

        public const string NotCorrectDateFormat = "The field {0} must be in format dd/MM/yyyy hh:ss";

        public const string InvalidValueType = "Invalid value type";
    }
}
