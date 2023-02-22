using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class AuthorManager
    {
        Repository<Author> repoAuthor = new Repository<Author>();
        public List<Author> GetAll()
        {
            return repoAuthor.List();
        }
        //Add new author
        public int AddAuthorBLL(Author p)
        {
            if(p.AuthorName=="")
            {
                return -1;
            }
            return repoAuthor.Insert(p);
        }
        public Author FindAuthorBLL(int id)
        {
            return repoAuthor.Find(x => x.AuthorID == id);
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
            return repoAuthor.Update(author);
        }
        public int DeleteAuthorBLL(int p)
        {
            Author author = repoAuthor.Find(x => x.AuthorID == p);
            return repoAuthor.Delete(author);
        }
    }
}
