using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        [Required(ErrorMessage = "Поле обов'язкове до заповнення!")]
        [Display(Name = "Ім'я")]
        public string FirstName { get; set; }
        [Display(Name = "По батькові")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Поле обов'язкове до заповнення!")]
        [Display(Name = "Прізвище")]
        public string LastName { get; set; }
        [Display(Name = "Заблокований")]
        public bool Blocked { get; set; }
    }
}
