using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.ViewModels.Catalog.Products
{
    public class ProductCreateRequestValidator : AbstractValidator<ProductCreateRequest>
    {
        public ProductCreateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Tên sản phẩm không được bỏ trống")
                ;

            RuleFor(x => x.Price).NotEmpty()
                .WithMessage("Giá bán không được bỏ trống");

            RuleFor(x => x.OriginalPrice).NotEmpty()
                .WithMessage("Giá nhập không được bỏ trống");

            RuleFor(x => x.Stock).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();


            RuleFor(x => x.Details).NotEmpty();


            RuleFor(x => x.SeoDescription).NotEmpty();

            RuleFor(x => x.SeoTitle).NotEmpty();

            RuleFor(x => x.SeoAlias).NotEmpty();

           
           



        }
    }
}
