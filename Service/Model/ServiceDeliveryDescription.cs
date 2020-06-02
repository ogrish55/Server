using System.Runtime.Serialization;


namespace Service.Model
{
    [DataContract]
    public class ServiceDeliveryDescription
    {
        [DataMember]
        public int DeliveryId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int ZipCode { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
    }
}
