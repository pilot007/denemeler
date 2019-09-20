using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebApplication.Controllers
{
    public class FormsController : Controller
    {

        public PartialViewResult StudentCreateView()
        {
            Student sx = new Student();
            int id = int.Parse(Session["studentId"].ToString());
            using (var context = new testEntities())
            {

               sx = (from b in context.Students
                         where b.Id == id
                     select b ).FirstOrDefault();

            }
            return PartialView("StudentCreateView", sx);
        }

        public PartialViewResult StudentPaymentView()
        {
            Student_Payments sx = new Student_Payments();
            return PartialView("StudentPaymentView",sx);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> save(Student model, string returnUrl)
        {
            //check for reportName parameter value now
            //to do : Return something
            testEntities ee = new testEntities();
            if (model.Id > 0) {
                ee.Entry(model).State = EntityState.Modified;
            }
            else
            { 
                ee.Students.Add(model);
            }
            ee.SaveChanges();


            using (var context = new testEntities())
            {
                ViewBag.PaymentsList = context.Student_Payments
                  .ToList();
            }


            var pp = ee.Student_Payments;            
            return View("General", pp);
        }


        public async Task<ActionResult> save_payment(Student_Payments model, string returnUrl)
        {
            int studentId= int.Parse(Session["studentId"].ToString());

            model.StudentId = studentId;
            //check for reportName parameter value now
            //to do : Return something
            testEntities ee = new testEntities();
            if (model.Id > 0)
            {
                ee.Entry(model).State = EntityState.Modified;
            }
            else
            {
                ee.Student_Payments.Add(model);
            }
            ee.SaveChanges();


            using (var context = new testEntities())
            {
                ViewBag.PaymentsList = context.Student_Payments
                  .Where(b => b.StudentId  == studentId)
                  .ToList();
            }
            
            return View("General", ViewBag.PaymentsList);
        }

        public ActionResult General(int studentId )
        {
            Session["studentId"]= studentId;
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
                  .Where(b => b.StudentId == studentId)
                  .ToList();

                ViewBag.PaymentsList = context.Student_Payments
                    .Where(b => b.StudentId == studentId)
                  .ToList();

            }
            /*            svm.Payments = new List<Student_Payments>();

                        foreach (var item in ee.Student_Payments)
                        {
                            svm.Payments.Add( new Student_Payments { Id=item.Id, Payment=item.Payment, StudentId=item.StudentId} );
                        }
                        */

            
            ViewBag.studentId = studentId;
            return View();
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