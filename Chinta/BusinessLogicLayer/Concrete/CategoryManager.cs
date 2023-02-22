using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class CategoryManager
    {
        Repository<Category> repocategory = new Repository<Category>();
        public List<Category> GetAll()
        {
            return repocategory.List();
        }
        public List<Category> CategoryByStatusTrue()
        {
            return repocategory.List(x => x.CategoryStatus == true);
        }
        public int AddNewCategoryBLL(Category p)
        {
            if(p.CategoryName=="" || p.CategoryDescription=="")
            {
                return -1;
            }
            return repocategory.Insert(p);
        }
        public Category FindCategoryBLL(int id)
        {
            return repocategory.Find(x => x.CategoryID == id);
        }
        public int EditCategoryBLL(Category p)
        {
            Category category = repocategory.Find(x => x.CategoryID == p.CategoryID);
            category.CategoryName = p.CategoryName;
            category.CategoryDescription = p.CategoryDescription;
            return repocategory.Update(category);
        }
        public int ActiveCategoryBLL(int id)
        {
            Category category = repocategory.Find(x => x.CategoryID == id);
            category.CategoryStatus = true;
            return repocategory.Update(category);
        }
        public int InactiveCategoryBLL(int id)
        {
            Category category = repocategory.Find(x => x.CategoryID == id);
            category.CategoryStatus = false;
            return repocategory.Update(category);
        }
        public int DeleteCategoryBLL(int p)
        {
            Category category = repocategory.Find(x => x.CategoryID == p);
            return repocategory.Delete(category);
        }
    }
}
