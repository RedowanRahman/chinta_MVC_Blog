using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class AboutManager
    {
        Repository<About> repoAbout = new Repository<About>();
        public List<About> GetAll()
        {
            return repoAbout.List();
        }
        public int UpdateAboutBLL(About p)
        {
            About about = repoAbout.Find(x => x.AboutID == p.AboutID);
            about.AboutImage1 = p.AboutImage1;
            about.AboutImage2 = p.AboutImage2;
            about.AboutContent1 = p.AboutContent1;
            about.AboutContent2 = p.AboutContent2;
            about.LinkedinLink = p.LinkedinLink;
            about.GithubLink = p.GithubLink;
            about.WebsiteLink = p.WebsiteLink;
            about.TwitterLink = p.TwitterLink;
            about.AboutID = p.AboutID;
            return repoAbout.Update(about);

        }
    }
}
