using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Service;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*** Console based host ***");
            using (ServiceHost serviceHost = new ServiceHost(typeof(ProductService)))
            using (ServiceHost productLineHost = new ServiceHost(typeof(ProductLineService)))
            using (ServiceHost customerOrderHost = new ServiceHost(typeof(CustomerOrderService)))
            using (ServiceHost customerHost = new ServiceHost(typeof(CustomerService)))
            using (ServiceHost deliveryDescriptionHost = new ServiceHost(typeof(DeliveryDescriptionService)))
            {
                // Open the hosts and start listening for incoming calls
                serviceHost.Open();
                productLineHost.Open();
                customerOrderHost.Open();
                customerHost.Open();
                deliveryDescriptionHost.Open();

                DisplayHostInfo(serviceHost);
                DisplayHostInfo(productLineHost);
                DisplayHostInfo(customerOrderHost);
                DisplayHostInfo(customerHost);
                DisplayHostInfo(deliveryDescriptionHost);

                Console.WriteLine("The services are ready.");
                Console.WriteLine("Press any key to terminate");
                Console.ReadLine();

            }
        }



        static void DisplayHostInfo(ServiceHost host)
        {
            Console.WriteLine();
            Console.WriteLine("*-- Host Info --*");

            foreach (System.ServiceModel.Description.ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine($"Address: {se.Address}");
                Console.WriteLine($"Binding: {se.Binding.Name}");
                Console.WriteLine($"Contract: {se.Contract.Name}");
            }
            Console.WriteLine("*---------------*");

        }
    }
}
