using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


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
        public string DiscountCode { get; set; }
        [DataMember]
        public int PaymentMethod { get; set; }
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public List<ServiceProductLine> ShoppingCart;
    }
}
