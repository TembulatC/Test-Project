using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.JWT
{
    public class JWTOptions
    {
        public string secretKey { get; set; } = string.Empty;
        public int expitesHours {  get; set; }
    }
}
