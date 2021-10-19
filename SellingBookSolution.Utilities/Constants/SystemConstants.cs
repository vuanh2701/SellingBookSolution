using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingBookSolution.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "SellingBookSolutionDb";
        public const string CartSession = "CartSession";
        public class AppSettings
        {
            public const string DefaultLanguageId = "DefaultLanguageId";
            public const string Token = "Token";

            public const string BaseAddress = "BaseAddress";


        }

        public class ProductSetting
        {
            public const int NumberOfFeaturedProduct = 4;
            public const int NumberOfLatestdProduct = 6;

        }

        public class ProductConstants
        {
            public const string NA = "N/A";
        }
    }
}
