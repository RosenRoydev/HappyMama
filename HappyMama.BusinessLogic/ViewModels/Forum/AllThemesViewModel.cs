using HappyMama.BusinessLogic.Enums;

namespace HappyMama.BusinessLogic.ViewModels.Forum
{
    public class AllThemesViewModel
	{
		public int ThemesCount { get; set; }
		public ICollection<ThemeFormViewModel> Themes { get; set; } = new List<ThemeFormViewModel>();
		public int currentPage { get; set; }	
		public int totalPages { get; set; }

        public string SearchTerm { get; set; } = string.Empty;

        public ThemeEnum Sorting { get; set; }
    }
}
