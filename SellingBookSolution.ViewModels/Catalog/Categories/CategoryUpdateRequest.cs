using SellingBookSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.ViewModels.Catalog.Categories
{
    public class CategoryUpdateRequest
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageId { set; get; }
        public string SeoAlias { set; get; }
        public Status Status { set; get; }
        public int? ParentId { set; get; }
    }
}
