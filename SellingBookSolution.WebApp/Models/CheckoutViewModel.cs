﻿using SellingBookSolution.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.WebApp.Models
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }

        public CheckoutRequest CheckoutModel { get; set; }
    }
}
