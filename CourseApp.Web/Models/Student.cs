using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Web.Models
{
    public class Student
    {
        [Required(ErrorMessage = "İsminizi giriniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Lütfen mail adresinizi düzgün giriniz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon giriniz.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Kursa katılım durumunuzu belirtiniz.")]
        public bool? WillAttend { get; set; }
    }
}
