using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMama.Infrastructure.Constants
{
    public static class DataValidationConstants
    {
        public const int EventNameMinLength = 3;
        public const int EventNameMaxLength = 50;

        public const double EventSumMin = 50;
        public const double EventSumMax = 500;

        public const int EventDescriptionMinLength = 3;
        public const int EventDescriptionMaxLength = 500;

        public const int NewsTitleMinLength = 3;
        public const int NewsTitleMaxLength = 80;

        public const int NewsDescriptionMinLength = 10;
        public const int NewsDescriptionMaxLength = 2000;

        public const string FormatForDate = "dd/MM/yyyy hh:ss";

        public const int ThemeTitleMinLength = 3;
        public const int ThemeTitleMaxLength = 100;

        public const int PostContentMinLength = 2;
        public const int PostContentMaxLength = 2000;

    }
}
