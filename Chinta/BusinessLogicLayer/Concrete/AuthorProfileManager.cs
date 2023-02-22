using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class AuthorProfileManager
    {
        Repository<Author> repoAuthor = new Repository<Author>();
        Repository<Blog> repoBlog = new Repository<Blog>();

        public List<Author> GetAuthorByMail(string p)
        {
            return repoAuthor.List(x => x.Mail == p);
        }
        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoBlog.List(x => x.AuthorID == id);
        }
        public int EditAuthorBLL(Author p)
        {
            Author author = repoAuthor.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorID = p.AuthorID;
            author.AuthorName = p.AuthorName;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorJob = p.AuthorJob;
            author.Mail = p.Mail;
            author.Password = p.Password;
            author.Phone = p.Phone;
            author.LinkedinLink = p.LinkedinLink;
            author.GithubLink = p.GithubLink;
            author.TwitterLink = p.TwitterLink;
            return repoAuthor.Update(author);
        }
        public int AuthorDeleteBlogBLL(int p)
        {
            Blog blog = repoBlog.Find(x => x.BlogID == p);
            return repoBlog.Delete(blog);
        }
    }
}
