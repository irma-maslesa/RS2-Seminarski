using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Filter
{
    public class ExceptionFilterAttribute : Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context) {
            if (context.Exception is UserException exception) {
                context.ModelState.AddModelError("message", exception.Message);
                context.ModelState.AddModelError("responseCode", ((int)exception.StatusCode).ToString());
                context.ModelState.AddModelError("responseDetail", exception.StatusCode.ToString());

                context.HttpContext.Response.StatusCode = (int)exception.StatusCode;
            }
            else {
                context.ModelState.AddModelError("message", "Server error!");
                context.ModelState.AddModelError("responseCode", ((int)HttpStatusCode.InternalServerError).ToString());
                context.ModelState.AddModelError("responseDetail", HttpStatusCode.InternalServerError.ToString());

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var list = context.ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, y => string.Join(" ", y.Value.Errors.Select(z => z.ErrorMessage)));

            context.Result = new JsonResult(list);
        }
    }
}
