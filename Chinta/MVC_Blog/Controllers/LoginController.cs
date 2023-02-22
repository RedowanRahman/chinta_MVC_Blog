using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_Blog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author p)
        {
            var authorInfo = c.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
            if(authorInfo != null)
            {
                FormsAuthentication.SetAuthCookie(authorInfo.Mail, true);
                Session["Mail"] = p.Mail.ToString();
                return RedirectToAction("AuthorBlogList", "AuthorPanel");
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var adminInfo = c.Admins.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (adminInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminInfo.Username, true);
                Session["Username"] = p.Username.ToString();
                return RedirectToAction("BlogListAdmin", "Blog");
            }
            else
            {
                return RedirectToAction("AdminLogin", "Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            
            Session.Abandon();
            
            Session.Remove("Mail");

            Session.Remove("Username");

            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache,no-store,max-age=0,must-revalidate");
            Response.AddHeader("Pragma", "no-cache");

            

            return RedirectToActionPermanent("AdminLogin", "Login");
        }
    }
}