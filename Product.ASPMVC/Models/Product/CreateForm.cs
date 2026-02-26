using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductLibrary.ASPMVC.Models.Product
{
    public class CreateForm
    {
        [DisplayName("Nom de produit: ")]
        [MaxLength(64, ErrorMessage ="Le nom ne doit pas dépasser 64 caractères.")]
        public string Name { get; set; }
        [DisplayName("Description de produit: ")]
        [MaxLength(512, ErrorMessage ="La description ne doit pas dépasser 512 caractères.")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        [DisplayName("Prix actuel: ")]
        public decimal CurrentPrice { get; set; }
    }
}
