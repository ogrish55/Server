using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class ServiceProductLine
    {
        public int ProductLineId { get; set; }
        public int Amount { get; set; }
        public int SubTotal { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
