using System.Runtime.Serialization;


namespace Service.Model
{
    [DataContract]
    public class ServiceDiscount
    {
        [DataMember]
        public string DiscountCode { get; set; }

        [DataMember]
        public decimal DiscountAmount { get; set; }
    }
}
