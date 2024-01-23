

using Challengue.Models;
using NHibernate;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
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
                profiles = session.Query<Profile>().ToList();
            }

            return View(profiles);  
        }

        public ActionResult Details(int id)
        {
            Profile profile = new Profile();
            using(ISession session = NHibernateSession.OpenSession())
            {
                profile = session.Query<Profile>().Where(p => p.Id == id).FirstOrDefault();
            }

            return View(profile);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
         public ActionResult Create(FormCollection collection)
        {
            try
            {
                Profile profile = new Profile();
                profile.Name = collection["Name"];
                profile.Age = collection["Age"];
                profile.City = collection["City"];

                using (ISession session = NHibernateSession.OpenSession())
                {
                    using(ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(profile);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }   
        }

        public ActionResult Delete(int id)
        {
            Profile profile = new Profile();
            using(ISession session = NHibernateSession.OpenSession())
            {
                profile = session.Query<Profile>().Where(p => p.Id == id).FirstOrDefault();
            }

            ViewBag.Message = "Confirm delete.";

            return View("Delete", profile) ;
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Profile profile = new Profile();
                using(ISession session = NHibernateSession.OpenSession())
                {
                    profile = session.Query<Profile>().Where(p => p.Id == id).FirstOrDefault();
                    using(ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(profile);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}