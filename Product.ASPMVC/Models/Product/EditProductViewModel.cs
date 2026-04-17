using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductLibrary.ASPMVC.Models.Product
{
    public class EditProductViewModel
    {
        [Required]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }
        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }
        [DisplayName("Nom du produit")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string Name { get; set; }
        [DisplayName("Description du produit")]
        public string Description { get; set; }
        [DisplayName("Prix actuel")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal CurrentPrice { get; set; }
    }
}
