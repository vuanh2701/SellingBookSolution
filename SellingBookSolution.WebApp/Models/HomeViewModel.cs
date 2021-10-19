using SellingBookSolution.ViewModels.Catalog.Products;
using SellingBookSolution.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideViewModel> Slides { get; set; }

        public List<ProductViewModel> FeaturedProducts { get; set; }
        public List<ProductViewModel> LatestProducts { get; set; }

    }
}
