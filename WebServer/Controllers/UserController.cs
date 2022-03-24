using Domain;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private ApplicationDbContext applicationDbContext;

        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ApplicationDbContext applicationDbContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<BFFUserInfoDTO> GetCurrentUser()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return BFFUserInfoDTO.Anonymous;
            }
            return new BFFUserInfoDTO()
            {
                Claims = User.Claims.Select(claim => new ClaimValueDTO { Type = claim.Type, Value = claim.Value }).ToList()
            };
        }

        [HttpGet("Logout")]
        public async Task<ActionResult> LogoutCurrentUser()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallback(string ReturnUrl = null)
        {
            var info = await signInManager.GetExternalLoginInfoAsync();
            if (info.Principal == null)
            {
                return Redirect("/User/Login");
            }
            var user = await userManager.FindByNameAsync(info.Principal.Identity.Name);
            if (info is not null && user is null)
            {
                ApplicationUser _user = new ApplicationUser
                {
                    UserName = info.Principal.Identity.Name,
                    IsOnline = false,
                };

                var result = await userManager.CreateAsync(_user);

                if (result.Succeeded)
                {
                    result = await userManager.AddLoginAsync(_user, info);
                    await signInManager.SignInAsync(_user, isPersistent: false, info.LoginProvider);
                    return LocalRedirect("/");
                }
            }

            var signInResult = await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: false);
            return signInResult switch
            {
                Microsoft.AspNetCore.Identity.SignInResult { Succeeded: true } => LocalRedirect("/"),
                _ => Redirect("/Error")
            };
        }
    }
}
