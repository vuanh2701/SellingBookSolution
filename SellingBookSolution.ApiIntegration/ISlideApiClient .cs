
using SellingBookSolution.ViewModels.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.ApiIntegration
{
    public interface ISlideApiClient
    {
        Task<List<SlideViewModel>> GetAll();
    }
}
