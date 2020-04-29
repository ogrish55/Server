using Service.Data;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Control
{
    public class DeliveryDescriptionControl
    {
        DataDeliveryDescription dataDeliveryDescription;
        public DeliveryDescriptionControl()
        {
            dataDeliveryDescription = new DataDeliveryDescription();
        }

        public void InsertDeliveryDescription(ServiceDeliveryDescription deliveryDescription)
        {
            dataDeliveryDescription.InsertDeliveryDescription(deliveryDescription);
        }

        public ServiceDeliveryDescription GetDeliveryDescriptionById(int deliveryId)
        {
            ServiceDeliveryDescription deliveryDescription = dataDeliveryDescription.GetDeliveryDescriptionById(deliveryId);
            return deliveryDescription;
        }

        public void UpdateDeliveryDescription(ServiceDeliveryDescription deliveryDescription)
        {
            dataDeliveryDescription.UpdateDeliveryDescription(deliveryDescription);
        }

        public void DeleteDeliveryDescription(int deliveryId)
        {
            dataDeliveryDescription.DeleteDeliveryDescription(deliveryId);
        }
    }
}
