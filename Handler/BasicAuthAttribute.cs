using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAuthentication.API.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthAttribute : TypeFilterAttribute
    {
        public BasicAuthAttribute(string header = @"My header") : base(typeof(BasicAuthenticationHandler))
        {
            Arguments = new object[] { header };
        }
    }
}
