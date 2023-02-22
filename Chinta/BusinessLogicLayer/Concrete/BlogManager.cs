using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class BlogManager
    {
        Repository<Blog> repoBlog = new Repository<Blog>();
        public List<Blog> GetAll()
        {
            return repoBlog.List();
        }
        public List<Blog> GetBlogByID(int id)
        {
            return repoBlog.List(x => x.BlogID == id);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoBlog.List(x => x.AuthorID == id);
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            return repoBlog.List(x => x.CategoryID == id);
        }
        public int BlogAddBLL(Blog p)
        {
            return repoBlog.Insert(p);
        }
        public int DeleteBlogBLL(int p)
        {
            Blog blog = repoBlog.Find(x => x.BlogID == p);
            return repoBlog.Delete(blog);
        }
        public Blog FindBlogBLL(int id)
        {
            return repoBlog.Find(x => x.BlogID == id);
        }
        public int UpdateBlogBLL(Blog p)
        {
            Blog blog = repoBlog.Find(x => x.BlogID == p.BlogID);
            blog.BlogTitle = p.BlogTitle;
            blog.BlogImage = p.BlogImage;
            blog.BlogDate = p.BlogDate;
            blog.BlogContent = p.BlogContent;
            blog.CategoryID = p.CategoryID;
            blog.AuthorID = p.AuthorID;
            return repoBlog.Update(blog);
        }

        public int ActiveBlogBLL(int id)
        {
            Blog blog = repoBlog.Find(x => x.BlogID == id);
            blog.BlogStatus = true;
            return repoBlog.Update(blog);
        }
        public int InactiveBlogBLL(int id)
        {
            Blog blog = repoBlog.Find(x => x.BlogID == id); 
            blog.BlogStatus = false;
            return repoBlog.Update(blog);
        }

    }
}
