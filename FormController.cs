using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication.Models;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class FormsController : Controller
    {

        public PartialViewResult StudentCreateView()
        {
            Student sx = new Student();
            return PartialView("StudentCreateView", sx);
        }
        public async Task<ActionResult> save(Student_Payments model, string returnUrl)
        {
            //check for reportName parameter value now
            //to do : Return something
            return View();
        }

        public ActionResult General()
        {
            /*            Entities1 ee = new Entities1();
                        Student ss = new Student
                        {
                            Id = 1,
                            Active = true,
                            StudentName = "test",
                            StudentSurName = "testSurname",
                            Adres="",
                            StudentPapier=true,
                            StudentPrice=0,
                            StudentRestPrice=0,
                            StudentExtraInfo="",
                            StudentBirthDate=""
                        };
                        ee.Students.Add(ss);
                        ee.SaveChanges();
                        var std = ee.Students.Find();

                         */

            /*
            var std = new Models.Student { Id = 1, Email = "test1@test.com", studentName = "STEFFY 1", studentSurName = "XYZ1" };
            var pymts = new List<Models.Student_Payments>();
            pymts.Add(new Models.Student_Payments { Id=1,Payment=100, date="1.1.2001"});
            pymts.Add(new Models.Student_Payments { Id = 2, Payment = 102, date = "1.1.2001" });
            pymts.Add(new Models.Student_Payments { Id = 3, Payment = 103, date = "1.1.2001" });
            std.payments=pymts.ToArray();
            */
            testEntities ee = new testEntities();
            /*
            ee.Students.Add( new Student {
                Id=1,
                StudentName ="test",
                StudentSurName ="test",
                StudentPrice=100,
                PhoneNumber="12345678"
            });

            ee.Students.Add(new Student
            {
                Id = 2,
                StudentName = "test",
                StudentSurName = "test2",
                StudentPrice = 200,
                PhoneNumber = "22345678"
            });

            ee.Students.Add(new Student
            {
                Id = 3,
                StudentName = "test2",
                StudentSurName = "test2x",
                StudentPrice = 300,
                PhoneNumber = "xx345678"
            });

            ee.Students.Add(new Student
            {
                Id = 4,
                StudentName = "test2",
                StudentSurName = "testy",
                StudentPrice = 500,
                PhoneNumber = "1R3T5Z78"
            });

            ee.Student_Payments.Add(new Student_Payments { Payment = 100, StudentId = 1 });
            ee.Student_Payments.Add(new Student_Payments { Payment = 200, StudentId = 1 });
            ee.Student_Payments.Add(new Student_Payments { Payment = 300, StudentId = 3 });
            ee.Student_Payments.Add(new Student_Payments { Payment = 400, StudentId = 3 });
            ee.Student_Payments.Add(new Student_Payments { Payment = 500, StudentId = 2 });
            ee.Student_Payments.Add(new Student_Payments { Payment = 600, StudentId = 2 });                
*/
            ee.SaveChanges();

            Student sx = new Student();

            StudentViewModel svm = new StudentViewModel();

            using (var context = new testEntities())
            {
                /*
                  var ss = from b in context.Students
                            where b.Id == 1
                            select b;
                */
                // Query for the Blog named ADO.NET Blog

                sx = context.Students
                                .Where(b => b.Id == 1)
                                .FirstOrDefault();
                svm.student = sx;

                svm.Payments = context.Student_Payments
                  .Where(b => b.Id == 1)
                  .ToList();

                ViewBag.PaymentsList = context.Student_Payments
                  .ToList();

            }
            /*            svm.Payments = new List<Student_Payments>();

                        foreach (var item in ee.Student_Payments)
                        {
                            svm.Payments.Add( new Student_Payments { Id=item.Id, Payment=item.Payment, StudentId=item.StudentId} );
                        }
                        */

            var pp = ee.Student_Payments;
            return View(pp);
        }


        public ActionResult Advanced()
        {
            return View();
        }
        public ActionResult Editors()
        {
            return View();
        }
    }
}
