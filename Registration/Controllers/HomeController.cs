using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Registration.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        //post
        [HttpPost]
        public ActionResult Register(uUser user)
        {
            try
            {
                RegistrationEntities1 db = new RegistrationEntities1();
                if (ModelState.IsValid)
                {
                    var result = db.uUsers.Where(x => x.Email == user.Email).Count();
                    if (result > 0)
                    {
                        //throw new Exception("User email just exists");
                        TempData["message"] = "Please enter different mail !!";
                        return View();

                    }
                    else
                    {
                        db.uUsers.Add(user);
                        db.SaveChanges();
                        TempData["message"] = "Siged Up Successfully, now you can log in !!";
                        return RedirectToAction("Login");

                    }
                }
                else
                {
                    return View();
                }

            }
            catch (Exception e)
            {
                TempData["message"] = "Couldn't Sign up, Please try again" + e.Message;
                return RedirectToAction("Register");
            }

            //return View();
        }

        public ActionResult ListUser(string SortOrder, string SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            RegistrationEntities1 db = new RegistrationEntities1();
            var result = db.uUsers.ToList();

            switch (SortBy)
            {
                case "User Name":
                    {
                        switch (SortOrder)
                        {
                            case "Ascending":
                                {
                                    result = result.OrderBy(x => x.UserName).ToList();
                                    break;
                                }
                            case "Descending":
                                {
                                    result = result.OrderByDescending(x => x.UserName).ToList();
                                    break;
                                }

                            default:
                                {
                                    result = result.OrderBy(x => x.UserName).ToList();
                                    break;
                                }
                        }

                        break;
                    }

                case "Email":
                    {
                        switch (SortOrder)
                        {
                            case "Ascending":
                                {
                                    result = result.OrderBy(x => x.Email).ToList();
                                    break;
                                }
                            case "Descending":
                                {
                                    result = result.OrderByDescending(x => x.Email).ToList();
                                    break;
                                }

                            default:
                                {
                                    result = result.OrderBy(x => x.Email).ToList();
                                    break;
                                }
                        }

                        break;
                    }

                case "password":
                    {
                        switch (SortOrder)
                        {
                            case "Ascending":
                                {
                                    result = result.OrderBy(x => x.Password).ToList();
                                    break;
                                }
                            case "Descending":
                                {
                                    result = result.OrderByDescending(x => x.Password).ToList();
                                    break;
                                }

                            default:
                                {
                                    result = result.OrderBy(x => x.Password).ToList();
                                    break;
                                }
                        }

                        break;
                    }
            }

            return View(result);
        }
        [HttpPost]
        public ActionResult ListUser(string search)
        {
            RegistrationEntities1 db = new RegistrationEntities1();
            var user = db.uUsers.ToList();
            if (search != null)
            {
                user = db.uUsers.Where(x => x.UserName.Contains(search) || x.Password.Contains(search) || x.Email.Contains(search)).ToList();
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Login(uUser userObj)
        {
            try
            {

                RegistrationEntities1 db = new RegistrationEntities1();
                var result = db.uUsers.Where(x => x.Email == userObj.Email && x.Password == userObj.Password).Count();
                if (result > 0)
                {
                    TempData["message"] = "Signned in successfully!!";
                    return RedirectToAction("ListUser");
                }
                else
                {
                    TempData["message"] = "Password or email didn't match!! please try again";
                }
                return View();



            }
            catch (Exception ex)
            {
                TempData["message"] = "Couldn't log in, please try again!" + ex.Message;
                return View(userObj);
            }
        }
    }
}