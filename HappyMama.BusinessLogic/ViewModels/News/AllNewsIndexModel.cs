using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMama.BusinessLogic.ViewModels.News
{
    public class AllNewsIndexModel
    {
        public int NewsCount {  get; set; }

        public ICollection<AllNewsViewModel> News { get; set; } = new List<AllNewsViewModel>();
        public int CurrentPage { get; set; }    
        public int TotalPages { get; set; }

    }
}
