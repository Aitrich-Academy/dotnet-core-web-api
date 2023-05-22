﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  HireMeNowWebApi.Exceptions
{
    [Serializable]
    public class ItemNotFoundException: Exception
    {
        public ItemNotFoundException()
        {
            
        }
        public ItemNotFoundException(string message)
        : base(message)
        {
        }
    }
}
