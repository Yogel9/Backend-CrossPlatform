using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Backend.Models; // класс Client

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Backend.Controllers
{
    public class AccountController : Controller
    {
        [ApiController]
        [Route("api/[controller]")]
        public class ValuesController : Controller
        {
            
            [HttpGet("token")]
            public string GetToken()
            {
                return AuthOptions.GenerateToken();
            }

            [HttpGet("token/secret")]
            public string GetAdminToken()
            {
                return AuthOptions.GenerateToken(true);
            }
        }
    }
}
