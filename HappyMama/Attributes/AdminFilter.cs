using HappyMama.BusinessLogic.Contracts;
using HappyMama.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HappyMama.Attributes
{
	public class AdminFilter : ActionFilterAttribute
	{
		

		public override   void OnActionExecuted(ActionExecutedContext context)
		{
			

			base.OnActionExecuted(context);

			var serviceProvider = context.HttpContext.RequestServices;
			var adminService = serviceProvider.GetService<IAdminService>();


			if (adminService == null)
			{
				context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
			}

			

			if (adminService != null &&  adminService.ExistAdminById(context.HttpContext.User.Id()).Result == false)
			{ 
			
			  context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
			}
		}
	}
}
