namespace HappyMama.BusinessLogic.ViewModels.Forum
{
	public class AllPostFormViewModel
	{
		public int TotalPosts { get; set; }

		public int CurrentPage { get; set; }	
		public ICollection<PostFormViewModel> Posts { get; set; } = new List<PostFormViewModel>();

		public int TotalPages { get; set; }
	}
}
