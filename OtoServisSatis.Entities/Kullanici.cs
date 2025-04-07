using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OtoServisSatis.Entities
{
   public class Kullanici : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Display(Name = "Ad"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Adi { get; set; }
        [MaxLength(50), Display(Name = "Soyad"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Soyadi { get; set; }
        [MaxLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Email { get; set; }
        [MaxLength(20)]
        public string? Telefon { get; set; }
        [MaxLength(50)]
        public string? KullaniciAdi { get; set; }


        [MaxLength(50), Display(Name = "Şifre"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Sifre { get; set; }


        public bool AktifMi { get; set; }

        [Display(Name ="Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? EklenmeTarihi { get; set; } = DateTime.Now;

        [Display(Name = "Rol Id"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public int RolId { get; set; }

        [Display(Name = "Rol Adı")]
        public Rol? Rol { get; set; }

        public Guid? UserGuid { get; set; } = Guid.NewGuid();




    }
}
