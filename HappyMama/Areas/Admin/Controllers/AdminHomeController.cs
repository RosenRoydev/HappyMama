using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace HappyMama.Areas.Admin.Controllers
{
    public class AdminHomeController : AdminController
    {
        private readonly IAdminService adminService;
        private readonly ITeacherService teacherService;

        public AdminHomeController(IAdminService _adminService,ITeacherService _teacherService)
        {
                adminService = _adminService;
                teacherService = _teacherService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllTeachers()
        {
            var model = await adminService.AllTeachersAsync();

            return View(model);
        }

        public async Task<IActionResult> AllParents()
        {
            var model = await adminService.AllParentsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ApproveTeacher()
        {
            var model = await teacherService.GetTeachersNotApprovedAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveTeacher(int Id)
        {
            await teacherService.ApproveTeacherAsync(Id);

            return RedirectToAction(nameof(ApproveTeacher));
        }
    }
}
