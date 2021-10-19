using SellingBookSolution.ViewModels.System.Users.Roles;
using SellingBookSolution.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.Application.Utilities.Slides
{ 
    public interface ISlideService
    {
        Task<List<SlideViewModel>> GetAll();
    }
}
