namespace HappyMama.BusinessLogic.Contracts
{
    public interface ITeacherService
    {
        Task AddTeacherAsync(string Id, string FirstName, string LastName);
        Task<bool>ExistTeacherByFirstNameAsync(string FirstName);
        Task<bool>ExistTeacherByLastNameAsync(string LastName);
        Task<bool> ExistById(string Id);
    }
}
