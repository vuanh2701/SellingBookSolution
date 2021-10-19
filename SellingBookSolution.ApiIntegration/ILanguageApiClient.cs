using SellingBookSolution.ViewModels.Common;
using SellingBookSolution.ViewModels.System.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.ApiIntegration
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageViewModel>>> GetAll();
    }
}
