using System.Web.Mvc;
using WebApplication.Models;
using System.Linq;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult DashboardV1()
        {
            using (var context = new testEntities())
            {

                var sx = (from b in context.Students
                          select b)
                          .ToList();

                return View(sx);

            }
        }
        public ActionResult DashboardV2()
        {
            return View();
        }
    }
}