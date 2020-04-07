using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    [DataContract]
    public class ServiceCustomerOrder
    {
        [DataMember]
        public decimal FinalPrice { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public DateTime DateOrder { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int DiscountId { get; set; }
        [DataMember]
        public string PaymentMethod { get; set; }

    }
}
