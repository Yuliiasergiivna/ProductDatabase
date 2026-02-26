using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductLibrary.ASPMVC.Models.Product
{
    public class CreateForm
    {
        [DisplayName("Nom de produit: ")]
        [MaxLength(ErrorMessage ="Le nom ne doit pas dépasser 64 caractères.")]
        public string Name { get; set; }
        [DisplayName("Description de produit: ")]
        public string? Description { get; set; }
        [DisplayName("Prix actuel: ")]
        public decimal CurrentPrice { get; set; }
    }
}
