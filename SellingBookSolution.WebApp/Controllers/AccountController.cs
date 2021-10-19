using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using SellingBookSolution.ApiIntegration;
using SellingBookSolution.Utilities.Constants;
using SellingBookSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;

        public AccountController(IUserApiClient userApiClient,
            IConfiguration configuration)
        {
            _userApiClient = userApiClient;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _userApiClient.Authenticate(request);
            if (result.ResultObject == null)
            {
                ModelState.AddModelError("", "Login fail");
                return View();
            }
            var userPrincipal = this.ValidateToken(result.ResultObject);
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };
            HttpContext.Session.SetString(SystemConstants.AppSettings.Token, result.ResultObject);
            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        authProperties);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        } 


        [HttpGet]
        public  IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }    

            var result = await _userApiClient.RegisterUser(request);
            if (!result.IsSuccessed)
            {
                ModelState.AddModelError("", result.Message);
                return View();
            }
            var loginResult = await _userApiClient.Authenticate(new LoginRequest() 
            {
                UserName = request.UserName,
                Password = request.Password,
                RememberMe = true
            });

            var userPrincipal = this.ValidateToken(loginResult.ResultObject);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = false
            };
            HttpContext.Session.SetString(SystemConstants.AppSettings.Token, loginResult.ResultObject);
            await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        authProperties);

            return RedirectToAction("Index", "Home");
        }

        //HÀM GIẢI MÃ TOKEN
        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
    }
}
