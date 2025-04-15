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

        /* 
         * 
         * 
         * Zimmetler tablosundaki KullananId kolonu ile Kullananlar tablosundaki Id kolonu arasında foreign key var.
         Kullananlar tablosundaki DemirbasId1 kolonu ile Demirbaslar tablosundaki Id kolonu arasında foreign key var.
        Zimmetler tablosundaki DemirbasId kolonu ile Demirbaslar tablosundaki Id kolonu arasında foreign key var.
        Demirbaslar tablosundaki MarkaId kolonu ile Markalar tablosundaki Id kolonu arasında foregn key var.
        Demirbaşlar tablosundaki KategoriId kolonu ile Kategoriler tablosundaki Id kolonu arasında foreign key var.
        Kullanicilar tablosundaki RolId kolonu ile Roller tablosundaki Id kolonu arasında foreign key var.
        Bu bilgiler doğrultusunda bana yardımcı ol. Bazı eksikliklerim ve yanlışlıklar var tablolar arasında. Kullananlar tablosunda, bir demirbaşı zimmet almış kullanıcıları listelemek istiyorum. Zimmetler tablosunda ise bir demirbaşı zimmet almış kullanıcıların yanı sıra zimmet aldıkları demirbaşları ve bu demirbaşların özelliklerini listelemek istiyorum. Kullanıcılar ve demirbaşlar tabloları arasında bir bağlantı olmalı. Kolon eksikleri falan da var yanılmıyorsam. Bu isteklerim için neler yapmalıyım
         */
    }

}
