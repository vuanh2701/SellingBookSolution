using SellingBookSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.ViewModels.System.Users
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>(); // gán giá trị mặc định bằng 1 list để nó không bị null
    }
}
