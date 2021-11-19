using BooksService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Books.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class RegistrationController
    {

        [Route("/api/v1/user/register")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<UserRegistrationResponse>> RegisterAsync([FromBody] UserRegistrationRequest request)
        {
            //return await RestMethod(request,
            //    _ => userValidator.Validate(_),
            //    async _ =>
            //    {
            //        var result = await userService.RegisterAsync(_, CancellationToken.None);

            //        if (result.ResponseCode != UserRegistrationResponse.RegistrationResponseCode.Success)
            //            return result;

            //        await userService.SaveAllChangesAsync();

            //        return result;
            //    });


        }

    }
}
