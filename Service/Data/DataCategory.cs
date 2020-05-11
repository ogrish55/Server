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
    public class DataCategory
    {
        private string _connectionString;
        public DataCategory()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["WebshopDatabase"].ConnectionString;
        }
        public IEnumerable<ServiceCategory> GetAllCategories()
        {
            List<ServiceCategory> categories = new List<ServiceCategory>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmdGetAllCategories = connection.CreateCommand())
                {
                    cmdGetAllCategories.CommandText = "SELECT name, categoryId FROM Category";
                    SqlDataReader categoryReader = cmdGetAllCategories.ExecuteReader();

                    while (categoryReader.Read())
                    {
                        ServiceCategory category = new ServiceCategory();
                        category.Name = categoryReader.GetString(categoryReader.GetOrdinal("name"));
                        category.CategoryId = categoryReader.GetInt32(categoryReader.GetOrdinal("categoryId"));

                        categories.Add(category);
                    }
                }
            }
            return categories;
        }
    }

}

