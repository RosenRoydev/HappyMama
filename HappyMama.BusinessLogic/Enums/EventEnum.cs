using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMama.BusinessLogic.Enums
{
    public enum EventEnum
    {
        [Display(Name = "Last date for payment")]
        DateLine = 0,
        [Display(Name = "Date Added")]
        DateAdded = 1,
        [Display(Name = "Amount for Event")]
        AmountForEvent = 2,
    }
}
