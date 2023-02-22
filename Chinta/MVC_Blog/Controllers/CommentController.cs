using BusinessLogicLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Blog.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager cm = new CommentManager();
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentList = cm.CommentByBlog(id).Where(y => y.CommentStatus == true);
            return PartialView(commentList);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            c.CommentStatus = false;
            cm.CommentAdd(c);
            return PartialView();
        }
        public ActionResult AdminCommentListTrue()
        {
            var commentList = cm.CommentByStatusTrue();
            return View(commentList);
        }
        public ActionResult StatusChangeToFalse(int id)
        {
            cm.StatusChangeToFalseBLL(id);
            return RedirectToAction("AdminCommentListTrue");
        }
        public ActionResult AdminCommentListFalse()
        {
            var commentList = cm.CommentByStatusFalse();
            return View(commentList);
        }
        public ActionResult StatusChangeToTrue(int id)
        {
            cm.StatusChangeToTrueBLL(id);
            return RedirectToAction("AdminCommentListFalse");
        }
        public ActionResult DeleteComment(int id)
        {
            cm.DeleteCommentBLL(id);
            return RedirectToAction("BlogListAdmin","Blog");

        }
    }
    
}