using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.Teacher;
using HappyMama.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;

namespace HappyMama.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly ITeacherService service;

        public TeacherController(ITeacherService _service)
        {
                service = _service;
        }


        [HttpGet]
        public IActionResult AddTeacher()
        {
            var model = new AddTeacherForm();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(AddTeacherForm model)
        {
            if (await service.ExistById(User.Id()))
            {
                return BadRequest();
            }

			if (await service.ExistTeacherByFirstNameAsync(model.FirstName) && 
                await service.ExistTeacherByLastNameAsync(model.LastName))
			{
				ModelState.AddModelError("Error", TeacherExist);
			}

		

			if (!ModelState.IsValid)
            {
                return View(model);
            }

           await  service.AddTeacherAsync(User.Id(),model.FirstName,model.LastName);

            return RedirectToAction(nameof(Index), "Home");
        }


    }
}
