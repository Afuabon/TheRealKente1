using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRealKente.Models
{
    public class Kente
    {
        public int Id { get; set; }

        [DisplayName("Product Code")]
        public string KenteID { get; set; }
        [Required]

        [DisplayName("Product Description")]
        public string Description { get; set; }

        public int StockQuantity { get; set; }
        [DisplayName("Price")]
        public double KentePrice { get; set; }

        [DisplayName("Product Image")]
        public string ProductImageURL { get;set; }

        public List<Order> Orders { get; set; }
        //public List<Customer> Customers { get; set; }

    }
}
