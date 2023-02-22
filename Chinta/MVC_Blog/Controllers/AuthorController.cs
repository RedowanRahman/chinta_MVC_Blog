using BusinessLogicLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Blog.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogManager = new BlogManager();
        AuthorManager authorManager = new AuthorManager();
        AuthorProfileManager authorProfile = new AuthorProfileManager();
        Context c = new Context();

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetail = blogManager.GetBlogByID(id);
            return PartialView(authorDetail);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var authorID = blogManager.GetAll().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
            var authorBlogs = blogManager.GetBlogByAuthor(authorID).Take(3).OrderByDescending(z => z.BlogID);
            return PartialView(authorBlogs);
        }
        public ActionResult AuthorList()
        {
            var authorLists = authorManager.GetAll();
            return View(authorLists);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            authorManager.AddAuthorBLL(p);
            return RedirectToAction("AuthorList");
        }
        [HttpGet]
        public ActionResult EditAuthor(int id)
        {
            Author author = authorManager.FindAuthorBLL(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult EditAuthor(Author p)
        {
            authorManager.EditAuthorBLL(p);
            return RedirectToAction("AuthorList");
        }
        public ActionResult AuthorBlogList(int id)
        {
            var blogs = authorProfile.GetBlogByAuthor(id);
            return View(blogs);
        }
        public ActionResult DeleteAuthor(int id)
        {
            authorManager.DeleteAuthorBLL(id);
            return RedirectToAction("AuthorList");

        }
    }
}