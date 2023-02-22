using BusinessLogicLayer.Concrete;
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
    [Authorize]
    public class AuthorPanelController : Controller
    {
        // GET: AuthorPanel
        AuthorProfileManager authorProfile = new AuthorProfileManager();
        Context c = new Context();
        BlogManager bm = new BlogManager();

        public ActionResult Index()
        {
            
            return View();
        }
        public PartialViewResult AuthorEdit(string p)
        {
            p = (string)Session["Mail"];
            var profileValues = authorProfile.GetAuthorByMail(p);
            return PartialView(profileValues);
        }
        
        public ActionResult UpdateAuthorProfile(Author p)
        {
            authorProfile.EditAuthorBLL(p);
            return RedirectToAction("Index");
        }
        public ActionResult AuthorBlogList(string p)
        {
            p = (string)Session["Mail"];
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = authorProfile.GetBlogByAuthor(id);
            return View(blogs);
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.FindBlogBLL(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values2 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values2 = values2;
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlogBLL(p);
            return RedirectToAction("AuthorBlogList");
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values2 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            bm.BlogAddBLL(b);
            return RedirectToAction("AuthorBlogList");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("Username");
            Session.Remove("Mail");
            Session.RemoveAll();
            return RedirectToAction("AuthorLogin", "Login");
        }

        public ActionResult AuthorDeleteBlog(int id)
        {
            authorProfile.AuthorDeleteBlogBLL(id);
            return RedirectToAction("AuthorBlogList");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentList = cm.CommentByBlog(id);
            return View(commentList);

        }
    }
}