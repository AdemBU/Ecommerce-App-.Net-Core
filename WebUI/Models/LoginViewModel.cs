using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
