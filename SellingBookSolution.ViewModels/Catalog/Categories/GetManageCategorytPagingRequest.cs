﻿using SellingBookSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.ViewModels.Catalog.Categories
{
    public class GetManageCategoryPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public string LanguageId { get; set; }
    }
}
