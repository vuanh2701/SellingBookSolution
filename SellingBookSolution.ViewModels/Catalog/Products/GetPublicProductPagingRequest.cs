using SellingBookSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.ViewModels.Catalog.Products
{

    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        //public string Keyword { get; set; }
        //public List<int> CategoryIds { get; set; }
        public int? CategoryId { get; set; }
        //public string  LangagueId { get; set; }
    }
}
