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
        public int ProductLineId { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public int SubTotal { get; set; }
        [DataMember]
        public int OrderId { get; set; }
        [DataMember]
        public ServiceProduct Product { get; set; }
    }
}
