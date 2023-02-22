using BusinessLogicLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Blog.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About
        AboutManager abm = new AboutManager();
        public ActionResult Index()
        {
            var aboutContent = abm.GetAll();
            return View(aboutContent);
        }
        public PartialViewResult Footer()
        {
            var aboutContent1 = abm.GetAll();
            return PartialView(aboutContent1);
        }
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager authorManager = new AuthorManager();
            var authorList = authorManager.GetAll().Take(3);
            return PartialView(authorList);
        }

        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutList = abm.GetAll();
            return View(aboutList);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            abm.UpdateAboutBLL(p);
            return RedirectToAction("UpdateAboutList");
        }
    }
}