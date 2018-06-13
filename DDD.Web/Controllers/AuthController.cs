using DDD.Domain;
using DDD.Service;
using DDD.Web.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace DDD.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserService userService;
        private readonly UserProfileService userProfileService;
        public AuthController()
        {
            userService = new UserService();
            userProfileService = new UserProfileService();
        }
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new UserLogin
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(UserLogin loginInfo)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            if (loginInfo.Email == "admin@admin.com" && loginInfo.Password == "pa55w0rd")
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,"Mock"),
                    new Claim(ClaimTypes.Email,"testing@gmail.com")
                }, "ApplicationCookie");
                var context = Request.GetOwinContext();
                var authMgr = context.Authentication;
                authMgr.SignIn(identity);
                return Redirect(GetRedirectUrl(loginInfo.ReturnUrl));
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "users");
            }
            return returnUrl;
        }



        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegistration userRegistration)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            List<UserRegistration> model = new List<UserRegistration>();
            userService.GetUsers().ToList().ForEach(u =>
            {
                UserProfile userProfile = userProfileService.GetUserProfile(u.Id);
                UserRegistration user = new UserRegistration
                {
                    Id = u.Id,
                    Name = $"{userProfile.FirstName} {userProfile.LastName}",
                    Email = u.Email,
                    Address = userProfile.Address.HomeAddress,
                    Password=userProfile.User.Password
                };
               model.Add(user);
                
            });

            return RedirectToAction("Login", "Auth");
                }
    }
}
