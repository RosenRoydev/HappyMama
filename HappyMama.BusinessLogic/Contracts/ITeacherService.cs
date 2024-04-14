using HappyMama.BusinessLogic.ViewModels.Teacher;

namespace HappyMama.BusinessLogic.Contracts
{
    public interface ITeacherService
    {
        Task AddTeacherAsync(string Id, string FirstName, string LastName);
        Task <bool>ExistTeacherByFirstNameAsync(string FirstName);
        Task <bool>ExistTeacherByLastNameAsync(string LastName);
        Task <bool> ExistById(string Id);
        Task <bool> IsApproved(string Id);
        Task ApproveTeacherAsync(int Id);
        Task <IEnumerable<AddTeacherForm>> GetTeachersNotApprovedAsync();
    }
}
