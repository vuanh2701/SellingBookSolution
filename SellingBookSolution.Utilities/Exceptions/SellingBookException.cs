using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;
using System.Runtime.Serialization;

namespace SellingBookSolution.Utilities.Exceptions
{
    public class SellingBookException : Exception
    {
        public SellingBookException()
        {
        }

        public SellingBookException(string message)
            : base(message)
        {
        }

        public SellingBookException(string message, Exception inner)
            : base(message, inner)
        {
        }


    }
}
