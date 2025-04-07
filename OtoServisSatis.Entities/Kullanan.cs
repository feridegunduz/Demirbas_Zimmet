using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Kullanan : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Demirbaş")]
        public string DemirbasId { get; set; }


        [MaxLength(50)]
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Adi { get; set; }


        [MaxLength(50)]
        [Display(Name = "Soyadı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Soyadi { get; set; }


        [MaxLength(11)]
        [Display(Name = "TC Numarası")]
        public string? TcNo { get; set; }


        [MaxLength(50)]
        public string Email { get; set; }


        [MaxLength(500)]
        public string? Adres { get; set; }


        [MaxLength(15)]
        public string? Telefon { get; set; }
        public string KullaniciAdi { get; set; }
        public string? Notlar { get; set; }
        [Display(Name = "Demirbaş")]

        public Demirbas? Demirbas { get; set; } 
    }
}
