namespace MessageHub.DAL
{
    public class KeyVal
    {
        public int Order { get; set; }
        public string Key { get; set; }        
        public string Val { get; set; }
        public string GID { get; set; } //Group ID for some sort of grouping 
        public string S1 { get; set; } //String Meta 1,2 & 3
        public string S2 { get; set; }
        public string S3 { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; } 
        public string F3 { get; set; } //Float Meta 1,2 & 3
    }
}
