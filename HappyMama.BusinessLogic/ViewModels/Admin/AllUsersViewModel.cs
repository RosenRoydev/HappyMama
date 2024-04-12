namespace HappyMama.BusinessLogic.ViewModels.Admin
{
    public class AllUsersViewModel
    {
        public string FirstName {  get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string CustomerAmount { get; set; } = string.Empty;
       
       public bool IsApproved { get; set; }

    }
}
