﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }

    public class ServiceResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
