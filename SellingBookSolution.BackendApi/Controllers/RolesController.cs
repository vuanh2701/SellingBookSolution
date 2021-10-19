using SellingBookSolution.Application.System.Roles;
using SellingBookSolution.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SellingBookSolution.Application.Utilities.Slides;

namespace SellingBookSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly ISlideService _roleService;

        public RolesController(ISlideService roleService)
        {
            _roleService = roleService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAll();
            return Ok(roles);
        }
    }
}
