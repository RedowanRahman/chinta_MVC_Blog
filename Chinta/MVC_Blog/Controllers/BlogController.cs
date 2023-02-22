using BusinessLogicLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVC_Blog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList()
        {

            //0.Post
            var postTitle0 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 0).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage0 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 0).Select(y => y.BlogImage).FirstOrDefault();
            var postDate0 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 0).Select(y => y.BlogDate).FirstOrDefault();
            var postID0 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 0).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.postTitle0 = postTitle0;
            ViewBag.postImage0 = postImage0;
            ViewBag.postDate0 = postDate0;
            ViewBag.postID0 = postID0;

            //1.Post
            var postTitle1 = bm.GetAll().OrderByDescending(z=>z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var postDate1 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var postID1=bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();
            ViewBag.postTitle1 = postTitle1;
            ViewBag.postImage1 = postImage1;
            ViewBag.postDate1 = postDate1;
            ViewBag.postID1 = postID1;


            //2.Post
            var postTitle2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postDate2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var postID2 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postTitle2 = postTitle2;
            ViewBag.postImage2 = postImage2;
            ViewBag.postDate2 = postDate2;
            ViewBag.postID2 = postID2;

            //3.Post
            var postTitle3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postDate3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var postID3 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postTitle3 = postTitle3;
            ViewBag.postImage3 = postImage3;
            ViewBag.postDate3 = postDate3;
            ViewBag.postID3 = postID3;

            //4.Post
            var postTitle4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postDate4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var postID4 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postTitle4 = postTitle4;
            ViewBag.postImage4 = postImage4;
            ViewBag.postDate4 = postDate4;
            ViewBag.postID4 = postID4;

            //5.Post
            var postTitle5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var postImage5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            var postDate5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            var postID5 = bm.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postTitle5 = postTitle5;
            ViewBag.postImage5 = postImage5;
            ViewBag.postDate5 = postDate5;
            ViewBag.postID5 = postID5;

            return PartialView(); 
        }
        
        public PartialViewResult RecentPosts(int page = 1)
        {
            var recentPost = bm.GetAll().OrderByDescending(z => z.BlogID).ToPagedList(page,6);
            return PartialView(recentPost);
        }           
        
        public ActionResult BlogDetails()
        {
            return View();
        }
        public PartialViewResult BlogCover(int id)
        {
            var blogCover = bm.GetBlogByID(id);
            return PartialView(blogCover);
        }
        
        public PartialViewResult BlogReadAll(int id)
        {
            var blogDetailsList = bm.GetBlogByID(id);
            return PartialView(blogDetailsList);
        }
        
        public ActionResult BlogByCategory(int id,int page=1)
        {
            var blogListByCategory = bm.GetBlogByCategory(id).ToPagedList(page,6);
            var CategoryName = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;
            var CategoryDescription = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDescription = CategoryDescription;
            return View(blogListByCategory);
        }
        public ActionResult BlogListAdmin()
        {
            var blogList = bm.GetAll();
            return View(blogList);
        }
        
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.values = values;
            List<SelectListItem> values2 = (from x in c.Authors.ToList() select new SelectListItem { Text = x.AuthorName, Value = x.AuthorID.ToString() }).ToList();
            ViewBag.values2 = values2;
            return View();
        }
        
        public ActionResult AddNewBlog(Blog b)
        {
            bm.BlogAddBLL(b);
            return RedirectToAction("BlogListAdmin");
        }
        public ActionResult DeleteBlog(int id)
        {
            bm.DeleteBlogBLL(id);
            return RedirectToAction("BlogListAdmin");
        }
       
        
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
        public ActionResult UpdateBlog(Blog p)
        {
            bm.UpdateBlogBLL(p);
            return RedirectToAction("BlogListAdmin");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager cm = new CommentManager();
            var commentList = cm.CommentByBlog(id);
            return View(commentList);

        }

        public ActionResult BlogActive(int id)
        {
            bm.ActiveBlogBLL(id);
            return RedirectToAction("BlogListAdmin");
        }
        public ActionResult BlogInactive(int id)
        {
            bm.InactiveBlogBLL(id);
            return RedirectToAction("BlogListAdmin");
        }


    }
}