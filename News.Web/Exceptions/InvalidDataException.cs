﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Exceptions
{
    public  class InvalidDataException : Exception
    {
        public  InvalidDataException():base("Invalid Data")
        {

        }

    }
}
