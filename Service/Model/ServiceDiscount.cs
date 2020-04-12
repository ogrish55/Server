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
        public int DiscountId { get; set; }

        [DataMember]
        public string DiscountCode { get; set; }

        [DataMember]
        public int DiscountAmount { get; set; }
    }
}
