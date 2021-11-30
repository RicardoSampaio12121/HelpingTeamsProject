/*
 * lufer
 * ISI
 * */
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;   //[Authorize]
using Microsoft.AspNetCore.Mvc;
using RESTAuth.Models;
using System.Collections.Generic;
using System.Linq;

namespace RESTAuth.Controllers
{
    /// <summary>
    /// Gestor de Autenticações - Authentication Manager
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

    }
}
