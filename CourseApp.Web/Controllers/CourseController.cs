using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Web.Controllers
{
    public class CourseController : Controller
    {
        //Course/MyView
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour > 12 ? "Good Afternoon" : "Good Morning";
            return View("MyView");
        }
        //Course/List
        public ViewResult List()
        {
            var liste = Repository.Students.Where(x => x.WillAttend == true).ToList();
            return View(liste);
        }

        public ViewResult Apply()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Apply(Student student)
        {
            //ASP.NET MVC yapısında FormCollection kullanarak Html.Helper ile yolladığımız form nesnesinden istediğimiz verileri alıp entity'mize göre eşitleme işlemi yapıyorduk. .Net Core 2'de ise TagHelper ile form yapısında asp-for içerisine Model olarak yolladığımız property'lerimiz için oluşması gereken inputlar otomatik oluşuyor, bu verileri POST etmek istediğimizde ise HttpPost metodumuzda FormCollection nesnesi parametre olarak almak yerine, Model Binding yapısı sayesinde View üzerinden yollanan entity tipinde parametre vererek entity nesnesini direkt olarak alabiliyoruz.
            //student entity'sine ait property verileri veri tabanına kayıt edilebilir.

            if (ModelState.IsValid)
            {
                Repository.AddStudent(student);
                return View("Thanks", student);
            }
            else
            {
                return View();
            }
        }
    }
}