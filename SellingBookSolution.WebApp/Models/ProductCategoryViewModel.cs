using SellingBookSolution.ViewModels.Catalog.Categories;
using SellingBookSolution.ViewModels.Catalog.Products;
using SellingBookSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryViewModel Category { get; set; }

        public PagedResult<ProductViewModel> Products { get; set; }
    }
}
