using System.Collections.Generic;
namespace MessageHub.DAL
{
    public class Msg
    {
        public string Id { get; set; } //Unique Guid
        public string Dst { get; set; } //Destination = "bcast", display_client_id, "trigger"
        public string Src { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
        public string Val { get; set; }
        public List<KeyVal> KVL { get; set; }
    }
}
