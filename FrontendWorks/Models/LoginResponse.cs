﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendWorks.Models
{
    public class LoginResponse
    {
        public string token {  get; set; }
        public UserInfo user { get; set; }
    }
}
