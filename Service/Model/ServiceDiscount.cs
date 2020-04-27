using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
