using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyCourseProject.ViewModels;
using UdemyCourseProject.Models;
using Microsoft.AspNetCore.Identity;
using UdemyCourseProject.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
namespace UdemyCourseProject.Controllers
{
    public class MainController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSend _emailSend;
        private readonly ISmsSend _smsSend;

        public MainController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IEmailSend emailSend,
            ISmsSend smsSend){
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSend = emailSend;
            _smsSend = smsSend;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResults = await
                    _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe,
                    lockoutOnFailure: false);
                if (loginResults.Succeeded)
                {
                    return RedirectToAction("Index", "LoggedIn");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Information");
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Username
                };

                var identityResults = await _userManager.CreateAsync(identityUser, model.Password);
                if (identityResults.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                    var callbackUrl = Url.Action("ConfirmEmail", "Main", new { userId = identityUser.Id, code = code },
                        protocol: HttpContext.Request.Scheme);
                    await _emailSend.SendEmailAsync(model.Username, "Confirm Account", $"Please confirm your accounty click this link:<a href='{callbackUrl}'>Link</a>");

                    await _signInManager.SignInAsync(identityUser, isPersistent: false);
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong when creating the user");
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View("ConfirmEmail");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if(user == null)
                {
                    return RedirectToAction("Index", "Main");
                }

                var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "LoggedIn");
                }
            }

            return View(model);
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    return View("ForgotPasswordConfirmation");
                }
                // Send Email Confirmation

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Main", new { userId = user.Id, code = code },
                    protocol: HttpContext.Request.Scheme);
                await
                    _emailSend.SendEmailAsync(model.Email, "Reset Password",
                        $"Please Reset your Password by clicking this link: <a href='{callbackUrl}'>Link</a>");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logoff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Main");
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        public async Task<IActionResult> TestEmail()
        {
            await _emailSend.SendEmailAsync("dzdykes88@gmail.com", "Test Email", "Welcome to testing your email sending thingy. This is my first Send Grid Email");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SmsTest()
        {
            await _smsSend.SendSmsAsync("14455559165", "This is a test message");

            return RedirectToAction("Index", "Main");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Main", new { returnUrl = returnUrl });

            var properties =
                _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            if(remoteError != null)
            {
                return View(nameof(ExternalLoginFailure));
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();

            if(info == null)
            {
                return RedirectToAction(nameof(ExternalLoginFailure));
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);

            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLoginConfirmation",
                    new ExternalLoginConfirmationViewModel { Email = email });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(
            ExternalLoginConfirmationViewModel model,
            string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

                var alreadyRegistered = await _userManager.FindByEmailAsync(model.Email);

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded || alreadyRegistered.UserName != null)
                {
                    result = await _userManager.AddLoginAsync(user, info);

                    if (result.Succeeded || alreadyRegistered.UserName != null)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        return RedirectToAction("Index", "LoggedIn");
                    }
                }
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }


        public IActionResult ExternalLoginFailure()
        {
            return View();
        }
    }
}
