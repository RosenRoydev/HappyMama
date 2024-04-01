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
        public Task EditNewsAsync (int id, NewsFormViewModel model);
        public Task <NewsFormViewModel>GetNewsById(int id);
        public Task DeleteNewsAsync (int id);
      
    }


}
