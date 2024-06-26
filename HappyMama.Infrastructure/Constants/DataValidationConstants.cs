﻿namespace HappyMama.Infrastructure.Constants
{
    public static class DataValidationConstants
    {
        public const int EventNameMinLength = 3;
        public const int EventNameMaxLength = 50;

        public const double EventSumMin = 50;
        public const double EventSumMax = 500;

        public const double EventSumForPayMin = 5;
        public const double EventSumForPayMax = 50;

        public const double  AmountMinValue = 30;
        public const double  AmountMaxValue = 300;

        public const int EventDescriptionMinLength = 3;
        public const int EventDescriptionMaxLength = 500;

        public const int NewsTitleMinLength = 3;
        public const int NewsTitleMaxLength = 80;

        public const int NewsDescriptionMinLength = 10;
        public const int NewsDescriptionMaxLength = 2000;

        public const string FormatForDate = "dd/MM/yyyy hh:mm";

        public const int ThemeTitleMinLength = 3;
        public const int ThemeTitleMaxLength = 100;

        public const int PostContentMinLength = 2;
        public const int PostContentMaxLength = 2000;

        public const int FirstNameMinLength = 3;
        public const int FirstNameMaxLength = 30;

        public const int LastNameMinLength = 3;
        public const int LastNameMaxLength = 30;

        public const int NicknameMinLength = 3;
        public const int NicknameMaxLength = 30;

        public const string DecimalPrecision = "18";
        public const string DecimalScale = "2";

    }
}
