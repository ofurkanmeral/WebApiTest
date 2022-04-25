using Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.statusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.statusCode
                };
            }
            return new ObjectResult(response)
            {
                StatusCode = response.statusCode
            };
        }
    }
}
