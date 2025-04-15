using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities
{
    public class Kategori : IEntity
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Kategori Adı"), Required(ErrorMessage = "{0} boş bırakılamaz!")]
        public string Adi { get; set; }
    }
}
