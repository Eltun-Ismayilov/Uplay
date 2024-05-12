using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uplay.Application.Helpers
{
    public static class Accessor
    {
        public static IConfiguration AppConfiguration { get; set; }
    }
}
