using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Mvc.Models
{
    public class RegisterViewModel

    {
        [Display(Name="İsim",Prompt ="İsim")]
        [MaxLength(100,ErrorMessage ="{0} en fazla {1} karakter olabilir")]
        public string? Name { get; set; }

        [Display(Name = "E-Mail", Prompt = "isim@örnek.com")]
        [MaxLength(200, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string? Email { get; set; }

        [Display(Name = "Şehir", Prompt = "İstanbul")]
        [MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string? City { get; set; }

        [Display(Name = "Şifre", Prompt = "Şifre")]
        [MaxLength(100, ErrorMessage = "{0} en fazla {1} karakter olabilir")]
        public string? Password { get; set; }

        [Display(Name = "Telefon", Prompt = "05432167890")]
        [MaxLength(100, ErrorMessage = "{0} en fazla 20 karakter olabilir")]
        public string? Phone { get; set; }
    }

}
