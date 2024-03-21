using HappyMama.BusinessLogic.Contracts;
using HappyMama.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HappyMama.Attributes
{
    public class TeacherEventFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var serviceProvider = context.HttpContext.RequestServices;
            var service = serviceProvider.GetService<ITeacherService>();

            if (service == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }

            if (service != null && service.ExistById(context.HttpContext.User.Id()).Result == false) 
            {

                context.Result =  new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
