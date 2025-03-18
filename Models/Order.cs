using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TheRealKente.Models
{     
        public class Order
        {
            [Key]
            public string OrderId { get; set; }

            public int OrderQuantity { get; set; }

            [DisplayName("Basket Total")]
            public double OrderTotal { get; set; }

            //Relationships

            public List<Kente> Kente { get; set; }
           // public List<Customer> Customers { get; set; }
        }
    

}
