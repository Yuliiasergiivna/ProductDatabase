using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductLibrary.ASPMVC.Models.Product
{
    public class ListItemViewModel
    {
        [ScaffoldColumn (false)] 
        public int ProductId { get; set; }
        [DisplayName("Nom de produit: ")]
        public string Name { get; set; }
        [DisplayName("Description de produit: ")]
        public string? Description { get; set; }
        [DisplayName("Prix actuel: ")]
        public decimal CurrentPrice { get; set; }
        [DisplayName("Quantité en stock: ")]
        public int Stock { get; set; }
    }
}
