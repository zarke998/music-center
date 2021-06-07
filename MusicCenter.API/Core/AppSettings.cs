using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCenter.API.Core
{
    public class AppSettings
    {
        public string JwtIssuer { get; set; }
        public string JwtSecretKey { get; set; }
        public string ApplicationInstance { get; set; }
    }
}
