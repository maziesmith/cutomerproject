using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerProject.Exceptions
{
    public class InvalidValueException : Exception
    {

        public InvalidValueException(String mssg) : base(mssg)
        {
      
        }

    }
}