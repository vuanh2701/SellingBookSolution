using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        [Display(Name = "Tên sách")]
        public string Name { get; set; }

        [Display(Name ="Giá bán")]
        public decimal Price { get; set; }

        [Display(Name = "Giá nhập")]
        public decimal OriginalPrice { set; get; }
        
        [Display(Name ="Số lượng nhập kho")]
        public int Stock { set; get; }

        
        public string Description { set; get; }

        [Display(Name = "Chi tiết")]
        public string Details { set; get; }

        
        public string SeoDescription { set; get; }

        [Display(Name = "Tiêu đề")]
        public string SeoTitle { set; get; }

        [Display(Name = "Tên khác")]
        public string SeoAlias { get; set; }

        public string LanguageId { set; get; }

        public bool? IsFeature { get; set; }

        [Display(Name = "Ảnh sản phẩm")]
        public IFormFile ThumbnailImage { get; set; }

        
    }
}
