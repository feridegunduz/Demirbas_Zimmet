using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**/
namespace OtoServisSatis.Entities
{
    public class Demirbas : IEntity
    {
        public int Id { get; set; }


        [Display(Name = "MarkaAdı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public int MarkaId { get; set; } = 1;


        [StringLength(50) , Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Kategori { get; set; }

        
        [MaxLength(50)] //Maksimum 50 karakter
        [Display(Name = "Seri Numarası")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string SeriNo { get; set; }



        [MaxLength(50)] //Maksimum 50 karakter
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string FaturaNo { get; set; } //kendimin

        [MaxLength(50)]
        [Display(Name = "Ürün Tipi")]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string UrunTipi { get; set; }



        [Display(Name = "Fatura tarihi ")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime FaturaTarihi { get; set; }



        [Display(Name = "Zimmetli Mi ?")]
        public bool ZimmetliMi { get; set; }



        [MaxLength(500)]
        [Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Notlar { get; set; }


        [StringLength(100)]
        public string? Resim1 { get; set; } // soru işareti boş geçilebilir


        [StringLength(100)]
        public string? Resim2 { get; set; }


        [StringLength(100)]
        public string? Resim3 { get; set; }

        public Marka? Marka { get; set; }



     

     
     
     







    }
}
