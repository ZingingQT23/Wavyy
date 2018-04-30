using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wavyy.Models;

namespace Wavyy.ViewModels
{
    public class NewUserViewModel : User
    {
        public string VPassword { get; set; }
        public string VEmail { get; set; }
    }
}