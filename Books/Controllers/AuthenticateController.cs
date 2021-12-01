﻿using BooksService.Models;
using BooksService.Services;
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
    public class AuthenticateController
    {
        private readonly IAuthenticateService authenticateService;

        public AuthenticateController(IAuthenticateService authenticateService)
        {
            this.authenticateService = authenticateService;
        }

        [Route("/api/v1/user/auth")]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<UserAuthenticateResponse>> AuthAsync([FromBody] UserAuthenticateRequest request)
        {
            return await authenticateService.AuthAsync(request);
        }

    }
}
