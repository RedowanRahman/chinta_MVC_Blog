using BusinessLogicLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Blog.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager();

        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = cm.CategoryByStatusTrue();

            return PartialView(categoryValues);
        }

        public ActionResult AdminCategoryList()
        {
            var categoryList = cm.GetAll();
            return View(categoryList);
        }
        public ActionResult AddNewCategory(Category p)
        {
            cm.AddNewCategoryBLL(p);
            return RedirectToAction("AdminCategoryList");
        }
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            Category category = cm.FindCategoryBLL(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.EditCategoryBLL(p);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryActive(int id)
        {
            cm.ActiveCategoryBLL(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryInactive(int id)
        {
            cm.InactiveCategoryBLL(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult DeleteCategory(int id)
        {
            cm.DeleteCategoryBLL(id);
            return RedirectToAction("AdminCategoryList");

        }
    }
}