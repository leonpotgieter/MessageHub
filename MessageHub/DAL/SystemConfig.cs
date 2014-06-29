using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHub.DAL
{
    public class SystemConfig
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> KV { get; set; }
    }
}
