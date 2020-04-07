using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class ServiceCustomerOrder
    {
        public decimal FinalPrice { get; set; }
        public string Status { get; set; }
        public DateTime DateOrder { get; set; }
        public int CustomerId { get; set; }
        public int DiscountId { get; set; }
        public string PaymentMethod { get; set; }

    }
}
