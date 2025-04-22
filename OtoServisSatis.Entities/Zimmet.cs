using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServisSatis.Entities
{
    public class Zimmet: IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Demirbas")]
        public int DemirbasId { get; set; }

        [Display(Name = "Müşteri"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public int MusteriId { get; set; }

        [Display(Name = "Zimmet Tarihi"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public DateTime ZimmetTarihi { get; set; }
        public Demirbas? Demirbas { get; set; }

        [Display(Name = "Kullanan"), Required(ErrorMessage = "{0} Boş bırakılamaz!")]
        public int KullananId{ get; set; } //fazlalık ?
        public Kullanan? Kullanan { get; set; }

       
    }

}
