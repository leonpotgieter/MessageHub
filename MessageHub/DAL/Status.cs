using System.Collections.Generic;
using System;
namespace MessageHub.DAL
{
    public class Status
    {
        public string Id { get; set; } //Unique Guid
        public string Src { get; set; }
        public string CurrentState { get; set; }
        public string BusyWithGuid { get; set; }
        public List<KeyValuePair<string, string>> KV { get; set; }
        public DateTime TS { get; set; }
        public Boolean Configured { get; set; }
    }
}
