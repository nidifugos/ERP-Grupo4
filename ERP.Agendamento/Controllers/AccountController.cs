using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using ERP.Agendamento.Models;

namespace ERP.Agendamento.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        Models.erp_agendamentoEntities entities = new Models.erp_agendamentoEntities();

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            /*
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuário ou senha incorretos.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
            */

            try
            {
                var user = (from us in entities.Users where us.Login == model.UserName select us).First();
                if (user.Senha == model.Password)
                {
                    Session["logged"] = user.Login;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["logged"] = "";
                    ModelState.AddModelError("", "Usuário ou senha incorretos.");                
                }                
            }
            catch
            {
                Session["logged"] = "";
                ModelState.AddModelError("", "Usuário ou senha incorretos.");
            }
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            /*
            FormsService.SignOut();
            */

            Session["logged"] = "";
            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            //ViewData["PasswordLength"] = 0;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            /*
            if (ModelState.IsValid)
            {               
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.Email);

                if (createStatus == MembershipCreateStatus.Success)
                {

                    FormsService.SignIn(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }                
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);

            */

            Models.User user = new Models.User();
            try
            {                
                user.Id = GetNewId();
                user.Login = model.UserName;
                user.Senha = model.Password;
                entities.AddToUsers(user);
                entities.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {                       
                ModelState.AddModelError("", "Não foi possível cadastrar usuário com id " + user.Id + 
                    " e login " + user.Login);
            }
            return View(model);
        }

        private string GetNewId()
        {
            /*
            try
            {
                var user = (from us in entities.Users select us).Last();            
                return Convert.ToString(Convert.ToInt32(user.Id) + 1);
            }
            catch
            {
                return "1";
            }
            */
            Random random = new Random();
            return Convert.ToString(random.Next());
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
    }
}
