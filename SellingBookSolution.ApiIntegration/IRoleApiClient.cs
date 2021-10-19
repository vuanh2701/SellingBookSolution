using SellingBookSolution.ViewModels.Common;
using SellingBookSolution.ViewModels.System.Users.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.ApiIntegration
{
    public interface IRoleApiClient
    {
        Task<ApiResult<List<RoleViewModel>>> GetAll();
    }
}