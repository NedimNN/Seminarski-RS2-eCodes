using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.InteropServices;
using eCodes.Models.Exceptions;

namespace eCodes.Filters
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is UserErrorException)
            {
                context.ModelState.AddModelError("ERROR", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if(context.Exception is ProductException)
            {
                context.ModelState.AddModelError("ERROR", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (context.Exception is PaymentException)
            {
                context.ModelState.AddModelError("ERROR", context.Exception.Message);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.ModelState.AddModelError("ERROR", "Server Error !");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            }

            var list = context.ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, y => y.Value.Errors.Select(z => z.ErrorMessage));

            context.Result = new JsonResult(list);
        }
    }
}
