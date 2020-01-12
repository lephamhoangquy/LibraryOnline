using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.Model
{
    public class CategoryModel
    {
        private int categoryID;
        private string categoryName;

        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }

        public CategoryModel()
        {
            categoryID = 0;
            categoryName = "";
        }

    }
}
