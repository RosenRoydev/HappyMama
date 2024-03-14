using System.ComponentModel.DataAnnotations;

namespace HappyMama.BusinessLogic.Constants
{
    public static class ErrorMessagesConstants
    {
        public const string RequiredLength = "The {0} field must be between {2} and {1} characters";

        public const string RequiredField = "The field {0} is required";

        public const string NeededAmountRestrict = "The sum for {0} must be between {1} and {2} BGN";

        public const string InvalidAmountFormat = "The format of Amount exist only digits and . between them";

        public const string NotCorrectDateFormat = "The Date  must be in format dd/MM/yyyy hh:mm:ss";

        public const string InvalidValueType = "Invalid value type";

        public const string TeacherExist = "Teacher with this names is already added in HappyMama";

        public const string ParentExist = "Parent with this names is already added in HappyMama";
	}
}
