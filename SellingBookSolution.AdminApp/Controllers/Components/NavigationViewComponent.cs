using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SellingBookSolution.AdminApp.Models;
using SellingBookSolution.ApiIntegration;
using SellingBookSolution.Utilities.Constants;
using SellingBookSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellingBookSolution.AdminApp.Controllers.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly ILanguageApiClient _languageApiClient;

        public NavigationViewComponent(ILanguageApiClient languageApiClient)
        {
            _languageApiClient = languageApiClient;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var languages = await _languageApiClient.GetAll();
            var navigationVm = new NavigationViewModel()
            {
                CurrentLanguageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId),
                Languages = languages.ResultObject
            };

            return View("Default", navigationVm)  ;
        }
    }
}
