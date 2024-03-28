using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMama.BusinessLogic.ViewModels.News
{
    public class AllNewsViewModel
    {
        public const int TotalNewsOnPage = 3;
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CreatedOn {  get; set; } = string.Empty;
        public string Creator {  get; set; } = string.Empty;


    }
}
