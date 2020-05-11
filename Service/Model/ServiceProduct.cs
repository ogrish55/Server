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
        public int BrandId { get; set; }
        [DataMember]
        public int CategoryId { get; set; }
        public override string ToString()
        {
            return $"{ProductId} {Name} {Price} ({Description})";
        }
        [DataMember]
        public byte[] rowId;
    }
}
