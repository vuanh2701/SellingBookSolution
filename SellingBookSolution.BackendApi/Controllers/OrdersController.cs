﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrdersController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
