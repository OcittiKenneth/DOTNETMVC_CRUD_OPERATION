using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TEST.PROJECT;
using TEST.Service;
using TEST.WEB.Models;

namespace TEST.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserProfileService userProfileService;

        public UserController(IUserService userService, IUserProfileService userProfileService)
        {
            this.userService = userService;
            this.userProfileService = userProfileService;
        }

        public IActionResult Index()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            this.userService.GetUsers().ToList().ForEach(u =>
            {
                UserProfile userProfile = this.userProfileService.GetUserProfile(u.Id);

                UserViewModel user = new UserViewModel
                {
                    Id = u.Id,
                    Name = $"{userProfile.FirstName} {userProfile.LastName}",
                    Email = u.Email,
                    Address = userProfile.Address
                };
                model.Add(user);
            });

            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel model)
        {
            User userentity = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                AddedDate = DateTime.Now,
                IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),

                UserProfile = new UserProfile { 
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                }
            };

            this.userService.InsertUser(userentity);
            if(userentity.Id > 0)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            UserViewModel model = new UserViewModel();
            if(id != 0)
            {
                User userEntity = this.userService.GetUser(id);
                UserProfile userProfileEntity = this.userProfileService.GetUserProfile(id);
                model.FirstName = userProfileEntity.FirstName;
                model.LastName = userProfileEntity.LastName;
                model.Address = userProfileEntity.Address;
                model.Email = userEntity.Email;
            }
            return View("EditUser", model);
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel model)
        {
            User userEntity = this.userService.GetUser(model.Id);
            userEntity.Email = model.Email;
            userEntity.ModifiedDate = DateTime.Now;
            userEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            UserProfile userProfileEntity = this.userProfileService.GetUserProfile(model.Id);
            userProfileEntity.FirstName = model.FirstName;
            userProfileEntity.LastName = model.LastName;
            userProfileEntity.Address = model.Address;
            userProfileEntity.ModifiedDate = DateTime.Now;
            userProfileEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            userEntity.UserProfile = userProfileEntity;
            this.userService.UpdateUser(userEntity); 

            if(userEntity.Id > 0)
            {
               
                return RedirectToActionPermanent("Index");
            }

            return View("EditUser", model);
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            UserViewModel model = new UserViewModel();
            if (id != 0)
            {
                UserProfile userProfileEntity = this.userProfileService.GetUserProfile(id);
                model.FirstName = userProfileEntity.FirstName;
                model.LastName = userProfileEntity.LastName;
            }
            return View("DeleteUser", model);
        }

        [HttpPost]
        public ActionResult DeleteUser(long id)
        {
            this.userService.DeleteUser(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult DetailsUser(int id)
        {
            UserViewModel model = new UserViewModel();
            if (id != 0)
            {
                User userEntity = this.userService.GetUser(id);
                UserProfile userProfileEntity = this.userProfileService.GetUserProfile(id);
                model.Id = userEntity.Id;
                model.FirstName = userProfileEntity.FirstName;
                model.LastName = userProfileEntity.LastName;
                model.Address = userProfileEntity.Address;
                model.Email = userEntity.Email;
                model.UserName = userEntity.UserName;
            }
            return View(model);
        }
    }
} 