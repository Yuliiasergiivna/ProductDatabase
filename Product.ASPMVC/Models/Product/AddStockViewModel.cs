using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductLibrary.ASPMVC.Models.Product
{
    public class AddStockViewModel
    {
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }
        [DisplayName("Nom du produit")]
        public string Name { get; set; }
        [DisplayName ("Quantité à ajouter/retirer")]
        [Required(ErrorMessage = "La quantité est obligatoire")]
        public int Quantity { get; set; }
    }
}
