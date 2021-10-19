using SellingBookSolution.ViewModels.Common;
using SellingBookSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.Application.System.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Authencate(LoginRequest request);
        //Task<string> Authencate(LoginRequest request);

        Task<ApiResult<bool>> Register(RegisterRequest request);

        Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request);

        Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPaging(GetUserPagingRequest request); // phương thức này lấy ra một danh sách user và trả về một model phân trang

        Task<ApiResult<UserViewModel>> GetById(Guid id);

        Task<ApiResult<bool>> Delete(Guid id);

        Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request);
    }
}
