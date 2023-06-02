using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Mvc.Models
{
    public class LoginViewModel
    {
        [Display(Name ="E-Mail",Prompt ="isim@örnek.com")]
        [Required(ErrorMessage ="{0} Gereklidir!")]
        public string Email { get; set; }

        [Display(Name = "Şifre", Prompt = "Şifre")]
        [Required(ErrorMessage = "{0} Gereklidir!")]
        public string Password { get; set; }
    }
}
