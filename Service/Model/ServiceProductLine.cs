using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    [DataContract]
    public class ServiceProductLine
    {
        [DataMember]
        public int productLineId { get; set; }
        [DataMember]
        public string amount { get; set; }
        [DataMember]
        public decimal subTotal { get; set; }
        [DataMember]
        public ServiceProduct product { get; set; }
        [DataMember]
        public string orderId { get; set; }

        public override string ToString()
        {
            return $"{productLineId} {amount} {subTotal} {product} ({orderId})";
        }
    }
}
