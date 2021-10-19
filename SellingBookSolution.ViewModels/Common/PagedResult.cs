using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.ViewModels.Common
{
    public class PagedResult<T> : PagedResultBase // để tất cả các phương thức ở nơi khác đều có thể gọi dưới dạng PagedViewModel<> để sử dụng, thay vì dùng List<>
    {
        public List<T> Items { get; set; }
    }
}

