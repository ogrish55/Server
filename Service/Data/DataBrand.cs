using Service.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Data
{
    public class DataBrand
    {
        private string _connectionString;
        public DataBrand()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["WebshopDatabase"].ConnectionString;
        }
        public IEnumerable<ServiceBrand> GetAllBrands()
        {
            List<ServiceBrand> brands = new List<ServiceBrand>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdGetAllBrands = connection.CreateCommand())
                {
                    cmdGetAllBrands.CommandText = "SELECT name, brandId FROM Brand";
                    SqlDataReader brandReader = cmdGetAllBrands.ExecuteReader();

                    while (brandReader.Read())
                    {
                        ServiceBrand brand = new ServiceBrand();
                        brand.Name = brandReader.GetString(brandReader.GetOrdinal("name"));
                        brand.BrandId = brandReader.GetInt32(brandReader.GetOrdinal("brandId"));

                        brands.Add(brand);
                    }
                }
            }
            return brands;
        }
    }
}
