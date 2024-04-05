namespace HappyMama.BusinessLogic.ViewModels.Forum
{
	public class PostFormViewModel
	{
		public static int PostPerPage { get; set; } = 10;	
		public int Id { get; set; }
		public string Content { get; set; } = string.Empty;

		public string Creator { get; set; } = string.Empty;

		public string CreatedOn { get; set; } = string.Empty ;

		public int ThemeId { get; set; }



	}
}