using DDD.Domain;
using DDD.Service;
using DDD.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDD.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService userService;
        private readonly UserProfileService userProfileService;
        public UserController()
        {
            userService = new UserService();
            userProfileService = new UserProfileService();

        }
        // GET: User
        //[HttpGet]
        public ActionResult Index()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            userService.GetUsers().ToList().ForEach(u =>
            {
                UserProfile userProfile = userProfileService.GetUserProfile(u.Id);
                UserViewModel user = new UserViewModel
                {
                    Id = u.Id,
                    Name = $"{userProfile.FirstName} {userProfile.LastName}",
                    Email = u.Email,
                    Address = userProfile.Address.HomeAddress
                };
                model.Add(user);
            });
            return View(model);
        }
    }
}