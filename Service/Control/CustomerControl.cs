using Service.Data;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Service.Control
{
    public class CustomerControl
    {
        DataCustomer dataCustomer;
        public CustomerControl()
        {
            dataCustomer = new DataCustomer();
        }
        public void DeleteCustomer(int customerId)
        {
            dataCustomer.DeleteCustomer(customerId);
        }

        public int InsertCustomer(ServiceCustomer customer)
        {
            string hash;
            string salt;
            GenerateSaltedHash(customer.Password, out hash, out salt);

            customer.Hash = hash;
            customer.Salt = salt;

            return dataCustomer.InsertCustomer(customer);

        }

        public void UpdateCustomer(ServiceCustomer customer)
        {
            dataCustomer.UpdateCustomer(customer);
        }

        private void GenerateSaltedHash(string password, out string hash, out string salt)
        {
            var saltBytes = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            salt = Convert.ToBase64String(saltBytes);

            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 30000);
            hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
        }

        public ServiceCustomer VerifyLogin(string enteredPassword, string email)
        {
            ServiceCustomer serviceCustomer = null;
            bool success = false;

            serviceCustomer = dataCustomer.GetCustomerByEmail(email);
            if (serviceCustomer != null)
            {
                success = VerifyPassword(enteredPassword, serviceCustomer.Hash, serviceCustomer.Salt);
                if (success == false)
                {
                    serviceCustomer = null;
                }
            }

            return serviceCustomer;
        }

        private bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 30000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }

        public ServiceCustomer GetCustomer(int id)
        {
            return dataCustomer.GetCustomerById(id);
        }
    }
}
