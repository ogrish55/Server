using Service.Control;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class DeliveryDescriptionService : IDeliveryDescriptionService
    {
        DeliveryDescriptionControl deliveryDescriptionControl;
        public DeliveryDescriptionService()
        {
            deliveryDescriptionControl = new DeliveryDescriptionControl();
        }
        public void InsertDeliveryDescription(ServiceDeliveryDescription deliveryDescription)
        {
            deliveryDescriptionControl.InsertDeliveryDescription(deliveryDescription);
        }

        public ServiceDeliveryDescription GetDeliveryDescriptionById(int deliveryId)
        {
            ServiceDeliveryDescription deliveryDescription = deliveryDescriptionControl.GetDeliveryDescriptionById(deliveryId);
            return deliveryDescription;
        }

        public void UpdateDeliveryDescription(ServiceDeliveryDescription deliveryDescription)
        {
            deliveryDescriptionControl.UpdateDeliveryDescription(deliveryDescription);
        }

        public void DeleteDeliveryDescription(int deliveryId)
        {
            deliveryDescriptionControl.DeleteDeliveryDescription(deliveryId);
        }

    }
}
