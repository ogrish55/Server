using System.Runtime.Serialization;


namespace Service.Model
{
    [DataContract]
    public class ServiceProductLine
    {
        [DataMember]
        public int ProductLineId { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public decimal SubTotal { get; set; }
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public ServiceProduct Product { get; set; }
    }
}
