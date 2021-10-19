using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SellingBookSolution.ApiIntegration;
using SellingBookSolution.Utilities.Constants;
using SellingBookSolution.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.AdminApp.Controllers.Components
{
    public class CategoryController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IConfiguration _configuration;
        private readonly ICategoryApiClient _categoryApiClient;


        public CategoryController(IProductApiClient productApiClient, IConfiguration configuration, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _configuration = configuration;
            _categoryApiClient = categoryApiClient;
        }


        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var request = new GetManageCategoryPagingRequest()
            {
                LanguageId = languageId,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Keyword = keyword
            };
            var categories = await _categoryApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {

            if (!ModelState.IsValid)
                return View(request);

            var result = await _categoryApiClient.CreateCategory(request);


            if (result)
            {
                TempData["result"] = "Thêm mới danh mục thành công";
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Thêm danh mục thất bại");

            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var category = await _categoryApiClient.GetById( languageId, id);
            var editVm = new CategoryUpdateRequest()
            {
                Id = category.Id,
                Name = category.Name,
                 SeoDescription = category.SeoDescription,
                 SeoAlias = category.SeoAlias,
                 SeoTitle = category.SeoTitle,
                 Status = category.Status,
                 ParentId = category.ParentId
            };
            return View(editVm);
        }


        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _categoryApiClient.UpdateCategory(request);
            if (result)
            {
                TempData["result"] = "Cập nhật danh mục thành công";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Cập nhật danh mục thất bại");
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            //var product = _productApiClient.GetById()
            return View(new CategoryDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _categoryApiClient.DeleteCategory(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa danh mục thất bại");
            return View(request);
        }
    }
}
