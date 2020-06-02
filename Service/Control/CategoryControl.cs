using Service.Data;
using Service.Model;
using System.Collections.Generic;


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
