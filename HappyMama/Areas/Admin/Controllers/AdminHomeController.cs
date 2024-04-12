using HappyMama.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HappyMama.Areas.Admin.Controllers
{
    public class AdminHomeController : AdminController
    {
        private readonly IAdminService adminService;

        public AdminHomeController(IAdminService _adminService)
        {
                adminService = _adminService;
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
    }
}
