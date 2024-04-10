using HappyMama.BusinessLogic.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMama.BusinessLogic.ViewModels.Event
{
    public class EventPayModel 
    {
        public int Id { get; set; }

        public string EventName { get; set; } = string.Empty;

        public decimal PaySum { get; set; }
    }
}
