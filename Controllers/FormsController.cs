using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebApplication.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using System.IO;

namespace WebApplication.Controllers
{
    public class FormsController : Controller
    {

        public ActionResult studentFileUpload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/files"),
                                               Path.GetFileName(file.FileName));

                    int id = int.Parse(Session["studentId"].ToString());

                    studentEntities ctx = new studentEntities();
                    student_files sf = new student_files();
                    sf.create_date = DateTime.Now;
                    sf.filepath = path;
                    sf.studentId = id;
                    sf.fileNameOld = file.FileName;

                    ctx.student_files.Add(sf);
                    ctx.SaveChanges();
                    string extension = Path.GetExtension(file.FileName);
                    sf.fileName = sf.id.ToString() + extension;
                    path = path.Replace(file.FileName, sf.id.ToString()+ extension);
                    ctx.Entry(sf).State = EntityState.Modified;
                    sf.filepath = path;
                    ctx.SaveChanges();

                    file.SaveAs(path);
                    ViewBag.Message = "Dosya yüklendi.";

                    using (var context = new studentEntities())
                    {
                        ViewBag.PaymentsList = context.Student_Payments
                          .Where(b => b.StudentId == id)
                          .ToList();
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return  View("General");
        }

        public PartialViewResult studentFileListView()
        {
            int id = 0;
            if (Session["studentId"] != null)
                id = int.Parse(Session["studentId"].ToString());
            using (var context = new studentEntities())
            {
                
                var filelist = (from b in context.student_files
                      where b.studentId == id
                      select b).ToList();

                return PartialView("studentFileListView", filelist);
            }
        }
        public PartialViewResult StudentCreateView()
        {
            Student sx = new Student();
            int id = 0;
            if (Session["studentId"]!=null)
              id = int.Parse(Session["studentId"].ToString());
            using (var context = new studentEntities())
            {

                sx = (from b in context.Students
                      where b.Id == id
                      select b).FirstOrDefault();

            }
            return PartialView("StudentCreateView", sx);
        }

        public PartialViewResult StudentPaymentView()
        {
            Student_Payments sx = new Student_Payments();
            return PartialView("StudentPaymentView", sx);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> save(Student model, string returnUrl)
        {
            //check for reportName parameter value now
            //to do : Return something
            studentEntities ee = new studentEntities();
            if (model.Id > 0)
            {
                ee.Entry(model).State = EntityState.Modified;
            }
            else
            {
                ee.Students.Add(model);
                Session["studentId"] = model.Id;

            }
            ee.SaveChanges();
            General(model.Id);
            return View("General");
        }


        public async Task<ActionResult> save_payment(Student_Payments model, string returnUrl)
        {
            int studentId = int.Parse(Session["studentId"].ToString());

            model.StudentId = studentId;
            //check for reportName parameter value now
            //to do : Return something
            studentEntities ee = new studentEntities();
            if (model.Id > 0)
            {
                ee.Entry(model).State = EntityState.Modified;
            }
            else
            {
                ee.Student_Payments.Add(model);
            }
            ee.SaveChanges();


            using (var context = new studentEntities())
            {
                ViewBag.PaymentsList = context.Student_Payments
                  .Where(b => b.StudentId == studentId)
                  .ToList();
            }

            return View("General", ViewBag.PaymentsList);
        }


        public ActionResult studentRechnung(int studentId)
        {
            string examdate = "";
            string discountnumber = "";
            string paymentrate = "";
            Student sx = new Student();
            using (var context = new studentEntities())
            {
                sx = context.Students
                                .Where(b => b.Id == studentId)
                                .FirstOrDefault();
                examdate = context.settings
                                .Where(b => b.value_name == "examdate")
                                .FirstOrDefault().value_desc;

                discountnumber = context.settings
                                .Where(b => b.value_name == "discountnumber")
                                .FirstOrDefault().value_desc;

                paymentrate = context.settings
                                .Where(b => b.value_name == "paymentrate")
                                .FirstOrDefault().value_desc;

            }
            ViewBag.studentId = studentId;
            ViewBag.examdate = examdate;
            ViewBag.studentName = sx.StudentName;
            ViewBag.studentSurName = sx.StudentSurName;
            ViewBag.studentAdres = sx.Adres;
            ViewBag.studentAdresCity = sx.AdresCity;
            ViewBag.studentAdresPLZ = sx.AdresPLZ;
            ViewBag.studentBirthDate = sx.StudentBirthDate;
            ViewBag.StudentPrice = sx.StudentPrice;
            ViewBag.StudentPriceDiscount = ((sx.StudentPrice / 100) * int.Parse(discountnumber));
            ViewBag.StudentPricerest = sx.StudentPrice - ViewBag.StudentPriceDiscount;
            ViewBag.StudentPriceRate = ViewBag.StudentPrice / int.Parse(paymentrate);
            ViewBag.mr = sx.mr_mrs;
            ViewBag.studentDate = DateTime.Now.Date.Day + "." + DateTime.Now.Date.Month + "." + DateTime.Now.Date.Year;
            if (DateTime.Now.Date.Month > 8)
            {
                ViewBag.studentJahr1 = DateTime.Now.Date.Year;
                ViewBag.studentJahr2 = DateTime.Now.Date.Year + 1;
                ViewBag.studentJahr = DateTime.Now.Date.Year + "/" + (DateTime.Now.Date.Year + 1);
            }
            else
            {
                ViewBag.studentJahr1 = DateTime.Now.Date.Year-1;
                ViewBag.studentJahr2 = DateTime.Now.Date.Year;
                ViewBag.studentJahr = (DateTime.Now.Date.Year - 1) + "/" + DateTime.Now.Date.Year;
        }

            return View();
        }
        public ActionResult studentPaper(int studentId)
        {
            Student sx = new Student();
            using (var context = new studentEntities())
            {
                sx = context.Students
                                .Where(b => b.Id == 1)
                                .FirstOrDefault();

            }
            ViewBag.studentId        = studentId;
            ViewBag.studentName      = sx.StudentName;
            ViewBag.studentSurName   = sx.StudentSurName;
            ViewBag.studentAdres     = sx.Adres;
            ViewBag.studentAdresCity = sx.AdresCity;
            ViewBag.studentAdresPLZ  = sx.AdresPLZ;
            ViewBag.studentBirthDate = sx.StudentBirthDate;
            ViewBag.mr = sx.mr_mrs;
            ViewBag.studentDate      = DateTime.Now.Date.Day+"."+ DateTime.Now.Date.Month+"."+DateTime.Now.Date.Year;
            if (DateTime.Now.Date.Month >8)
                ViewBag.studentJahr      = DateTime.Now.Date.Year +"/"+ (DateTime.Now.Date.Year+1);
            else
                ViewBag.studentJahr = (DateTime.Now.Date.Year-1 )+ "/" + DateTime.Now.Date.Year;

            return View();
        }

        public ActionResult General(int studentId)
        {
            Session["studentId"] = studentId;
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
            studentEntities ee = new studentEntities();
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

         
            using (var context = new studentEntities())
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