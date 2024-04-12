using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HappyMama.BusinessLogic.Constants.RoleConstants;

namespace HappyMama.Areas.Admin.Controllers
{
    [Area(NameArea)]
    [Authorize(Roles = AdminRole)]
    public class AdminController : Controller
    {

    }
}
