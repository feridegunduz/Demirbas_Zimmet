using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.WebUI.Models
{
    public class CustomerLoginViewModel
    {

        [MaxLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Email { get; set; }


        [MaxLength(50), Display(Name = "Şifre"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Sifre { get; set; }

    }
}
