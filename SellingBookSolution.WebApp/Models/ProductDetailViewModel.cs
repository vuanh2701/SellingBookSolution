using SellingBookSolution.ViewModels.Catalog.Categories;
using SellingBookSolution.ViewModels.Catalog.ProductImages;
using SellingBookSolution.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.WebApp.Models
{
    public class ProductDetailViewModel
    {
        public CategoryViewModel Category { get; set; }

        public ProductViewModel Product { get; set; }

        public List<ProductViewModel> RelatedProducts { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
    }
}
