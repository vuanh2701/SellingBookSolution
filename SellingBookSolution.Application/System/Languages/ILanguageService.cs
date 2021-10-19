using SellingBookSolution.ViewModels.Common;
using SellingBookSolution.ViewModels.System.Languages;
using SellingBookSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.Application.System.Languages
{
    public interface ILanguageService
    {
        Task<ApiResult<List<LanguageViewModel>>> GetAll();
        
    }
}
