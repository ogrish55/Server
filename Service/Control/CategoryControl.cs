using Service.Data;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Control
{
    public class CategoryControl
    {
        private DataCategory dataCategory;
        public CategoryControl()
        {
            dataCategory = new DataCategory();

        }
        public IEnumerable<ServiceCategory> GetAllCategories()
        {
            return dataCategory.GetAllCategories();
        }
    }
}
