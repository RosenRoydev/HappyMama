using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Services;
using HappyMama.BusinessLogic.ViewModels.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace HappyMama.Areas.Admin.Controllers
{
    public class AdminHomeController : AdminController
    {
        private readonly IAdminService adminService;
        private readonly ITeacherService teacherService;
        private readonly IParentService parentService;

        public AdminHomeController(IAdminService _adminService,ITeacherService _teacherService, IParentService _parentService)
        {
                adminService = _adminService;
                teacherService = _teacherService;
                parentService = _parentService;
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

        [HttpGet] 

        public async Task<IActionResult> ApproveParent()
        {
            var model = await parentService.GetParentsNotApprovedAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveParent(int Id)
        {
            await parentService.ApproveParentAsync(Id);

            return RedirectToAction(nameof(ApproveParent));
        }
    }
}
