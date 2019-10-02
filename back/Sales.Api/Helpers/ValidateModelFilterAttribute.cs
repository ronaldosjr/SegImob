using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sales.Api.Helpers
{
    public class ValidateModelFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)            
                context.Result = new BadRequestObjectResult(context.ModelState.Values.ToInlineError());
        }
    }
}
