using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Api.Core
{
    public class JwtSettings
    {
        public int Minutes { get; set; }
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
    }
}
