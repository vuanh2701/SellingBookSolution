using SellingBookSolution.Application.CataLog.Products;
using SellingBookSolution.ViewModels.Catalog.ProductImages;
using SellingBookSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SellingBookSolution.BackendApi.Controllers
{
    //api/products
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _prosuctService;


        public ProductsController(IProductService productService)
        {
            _prosuctService = productService;
        }



        // http://localhost:port/product?publicIndex= &pageSize=10&categoryId=
        [HttpGet("{langagueId}")]
        public async Task<IActionResult> GetAllPaging(string langagueId, [FromQuery] GetPublicProductPagingRequest request) // tất cả những phương thức của GetPublicProductPagingRequest đưuọc gọi từ query
        {
            var products = await _prosuctService.GetAllByCategoryId(langagueId, request);

            return Ok(products);
        }

        // http://localhost:port/product?publicIndex= &pageSize=10&categoryId=
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageProductPagingRequest request) // tất cả những phương thức của GetPublicProductPagingRequest đưuọc gọi từ query
        {
            var products = await _prosuctService.GetAllPaging(request);

            return Ok(products);
        }


        // http://localhost:port/product/1
        [HttpGet("{productId}/{langagueId}")]
        public async Task<IActionResult> GetById(int productId, string langagueId)
        {
            var product = await _prosuctService.GetById(productId, langagueId);
            if (product == null)
            {
                return BadRequest("Cannot find product");
            }
            return Ok(product);
        }


        [HttpGet("featured/{langagueId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFeaturedProducts(int take, string langagueId)
        {
            var products = await _prosuctService.GetFeaturedProducts(langagueId, take);
                
            return Ok(products);
        }

        [HttpGet("latest/{langagueId}/{take}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestdProducts(int take, string langagueId)
        {
            var products = await _prosuctService.GetLatestProducts(langagueId, take);

            return Ok(products);
        }

        //[HttpGet("{productId}/{langagueId}")]
        //public async Task<IActionResult> GetAllPaging()
        //{

        //    return Ok();
        //}


        [HttpPost]
        [Authorize]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _prosuctService.Create(request);
            if (productId == 0)
            {
                return BadRequest();
            }
            var product = await _prosuctService.GetById(productId, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id = productId }, product);
        }

        [HttpPut("{productId}")]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int productId,[FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = productId;
            var affectedResult = await _prosuctService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{productId}")]
        [Authorize]
        public async Task<IActionResult> Delete(int productId)
        {

            var affectedResult = await _prosuctService.Delete(productId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        // nếu update 1 phần thì không dùng HttpPut, mà dùng HttpPatch

        [HttpPatch("{productId}/{newPrice}")]
        [Authorize]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var isSuccessful = await _prosuctService.UpdatePrice(productId, newPrice);
            if (isSuccessful) return Ok();
            return BadRequest();
        }


        //[HttpPut("stock/{productId}/{newStock")]
        //public async Task<IActionResult> UpdateStock(Guid productId, Guid addedQuantity) 
        //{
        //    var stock = await _manageProsuctService.UpdateStock(productId, addedQuantity);
        //    if (stock) return Ok();
        //    return BadRequest();
        //}


        //Images
        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImagebyId(int productId, int imageId)
        {
            var image = await _prosuctService.GetImageById(imageId);
            if (image == null)
            {
                return BadRequest("can not find image with productId: " + imageId);
            }
            return Ok(image);
        }


        [HttpGet("{productId}/listImage")]
        public async Task<IActionResult> GetListImage(int productId)
        {
            var image = await _prosuctService.GetListImages(productId);
            if (image == null)
            {
                return BadRequest("can not find image with productId: " + productId);
            }
            return Ok(image);
        }


        [HttpPost("{productId}/images")]  // Tất cả hàm Post nên trả về 201 - là created
        public async Task<IActionResult> CreateImage([FromForm] int productId, ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _prosuctService.AddImage(productId, request);
            if (imageId == 0)
            {
                return BadRequest();
            }

            var image = await _prosuctService.GetImageById(imageId);

            return CreatedAtAction(nameof(GetImagebyId), new { id = imageId }, image);
        }



        [HttpPut("{productId}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> UpdateImage([FromForm] int imageId, ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _prosuctService.UpdateImage(imageId, request);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok();
        }


        [HttpDelete("{productId}/images/{imageId}")]
        [Authorize]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var image = await _prosuctService.RemoveImage(imageId);
            if (image == 0)
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpPut("{id}/categories")]
        [Authorize]
        public async Task<IActionResult> CategoryAssign(int id, [FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _prosuctService.CategoryAssign(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


    }
}
