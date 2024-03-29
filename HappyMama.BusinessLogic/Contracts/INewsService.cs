using HappyMama.BusinessLogic.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMama.BusinessLogic.Contracts
{
    public interface INewsService
    {
        public Task<AllNewsIndexModel> AllNewsAsync(int currentpage = 1, int totalNewsOnPage = 1);
        public Task AddNewsAsync(string Id, NewsFormViewModel model);
    }


}
