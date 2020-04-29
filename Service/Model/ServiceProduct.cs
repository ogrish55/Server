using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    [DataContract]
    public class ServiceProduct
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int AmountOnStock { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public string Category { get; set; }
        public override string ToString()
        {
            return $"{ProductId} {Name} {Price} ({Description})";
        }

        public byte[] rowId;
    }
}
