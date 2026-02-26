using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductLibrary.ASPMVC.Models.Stock
{
    public class StockEntryViewModel
    {
        [DisplayName("Date d'operation")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }
        [DisplayName("Quantité d'operation")]
        public int StockOperation { get; set; }
        public string OperationType => StockOperation > 0 ? "Ajoute" : "Retrait";
    }
}
