using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore7WebAPI.Infrastructure.Tokens
{
    public class TokenSettings
    {
        public string Audience { get; set; }
        public string Issure { get; set; }
        public string Secret { get; set; }
        public int TokenValidityMinutes { get; set; }

    }
}
