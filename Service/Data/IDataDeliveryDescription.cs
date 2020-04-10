using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public interface IDataDeliveryDescription
    {
        void InsertDeliveryDescription(ServiceDeliveryDescription deliveryDescription);
        ServiceDeliveryDescription GetDeliveryDescriptionById(int deliveryId);
        int UpdateDeliveryDescription(ServiceDeliveryDescription deliveryDescription);
        int DeleteDeliveryDescription(int deliveryId);
    }
}
