using HappyMama.BusinessLogic.Contracts;
using HappyMama.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;

namespace HappyMama.Attributes
{
    public class ParentFilter : ActionFilterAttribute
    {
        

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var  serviceProvider = context.HttpContext.RequestServices;

            var  service = serviceProvider.GetService<IParentService>();

            if (service == null)
            {   
                
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }

            if (service != null &&  service.ExistByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
