using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    [ServiceContract]
    public interface IDeliveryDescriptionService
    {
        [OperationContract]
        void InsertDeliveryDescription(ServiceDeliveryDescription deliveryDescription);

        [OperationContract]
        ServiceDeliveryDescription GetDeliveryDescriptionById(int deliveryId);

        [OperationContract]
        void UpdateDeliveryDescription(ServiceDeliveryDescription deliveryDescription);

        [OperationContract]
        void DeleteDeliveryDescription(int deliveryId);
    }
}
