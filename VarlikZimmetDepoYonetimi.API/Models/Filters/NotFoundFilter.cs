using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VarlikZimmetDepoYonetimi.API.Models.DTO;

namespace VarlikZimmetDepoYonetimi.API.Models.Filters
{
    public class NotFoundFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var parametre = (int)context.ActionArguments.Values.FirstOrDefault();
            if (parametre >= 0)
            {
                next();
            }
            else
            {
                ErrorDTO dto = new ErrorDTO();
                dto.StatusCode = 400;
                dto.ErrorDesc.Add($"{parametre}  nolu veri bulunamadı..");
                dto.ErrorDesc.Add($"{parametre}  nolu veri 0 dan buyuk değil..");
                context.Result = new NotFoundObjectResult(dto);
            }
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
