

using Challengue.Models;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Challengue.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult List()
        {
            ViewBag.Message = "Your application description page.";
            IList<Profile> profiles;

            using(ISession session = NHibernateSession.OpenSession())
            {
                profiles = session.Query<Profile>.ToList();
            }

            return View(profiles);  
        }
    }
}