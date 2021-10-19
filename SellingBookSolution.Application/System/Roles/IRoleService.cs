using SellingBookSolution.ViewModels.System.Users.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleViewModel>> GetAll();
    }
}
