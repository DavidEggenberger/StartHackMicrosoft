using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebServer.Services;

namespace WebServer.Pages
{
    public class LoginModel : PageModel
    {
        public SignInManager<ApplicationUser> SignInManager;
        private readonly TranslatorService translationService;

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }
        public LoginModel(SignInManager<ApplicationUser> signInManager, TranslatorService translationService)
        {
            SignInManager = signInManager;
            this.translationService = translationService;
        }
        public async Task<ActionResult> OnPostAsync([FromForm] string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "User", new { returnUrl });
            var properties = SignInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            string s = await translationService.TranslateToEnglisch("Hallo hallo ich bin David", "de-CH");
            return Challenge(properties, provider);
        }
    }
}
