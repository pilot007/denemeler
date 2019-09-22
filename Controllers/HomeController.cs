using System.Web.Mvc;
using WebApplication.Models;
using System.Linq;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult DashboardV1()
        {
            using (var context = new studentEntities())
            {

                var sx = (from b in context.Students
                          select b)
                          .ToList();
                ViewBag.activeStudent = (from b in context.Students
                                         .Where(b => b.Active == true)
                                         select b)
                          .ToList().Count();

                ViewBag.allStudent = (from b in context.Students
                                      .Where(b => b.Active == false)
                                      select b)
                          .ToList().Count();


                return View(sx);

            }
        }
        public ActionResult DashboardV2()
        {
            return View();
        }
    }
}