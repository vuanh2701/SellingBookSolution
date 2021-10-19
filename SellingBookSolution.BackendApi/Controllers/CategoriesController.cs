﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SellingBookSolution.Application.Catalog.Categories;
using SellingBookSolution.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var products = await _categoryService.GetAll(languageId);

            return Ok(products);
        }

        //[HttpGet("{id}/{languageId}")]
        //public async Task<IActionResult> GetById(string languageId, int id)
        //{
        //    var category = await _categoryService.GetById(id, languageId );

        //    return Ok(category);
        //}

        [HttpGet("{categoryId}/{langagueId}")]
        public async Task<IActionResult> GetById(int categoryId, string langagueId)
        {
            var category = await _categoryService.GetById(categoryId, langagueId);
            if (category == null)
            {
                return BadRequest("Cannot find product");
            }
            return Ok(category);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageCategoryPagingRequest request) // 
        {
            var categories = await _categoryService.GetAllPaging(request);

            return Ok(categories);
        }

        [HttpPost]
        [Authorize]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryId = await _categoryService.Create(request);
            if (categoryId == 0)
            {
                return BadRequest();
            }
            var category = await _categoryService.GetById(categoryId, request.LanguageId );
            return CreatedAtAction(nameof(GetById), new { id = categoryId }, category);
        }

        [HttpPut("{categoryId}")]
        [Authorize]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] int categoryId, [FromForm] CategoryUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             request.Id = categoryId;
            var affectedResult = await _categoryService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{categoryId}")]
        [Authorize]
        public async Task<IActionResult> Delete(int categoryId)
        {

            var affectedResult = await _categoryService.Delete(categoryId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
