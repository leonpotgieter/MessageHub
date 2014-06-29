using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHub.DAL
{
    public class Content
    {
        public string Id { get; set; }
        public string Guid { get; set; }
        public string Displayclient { get; set; } //target client
        public string Contenttype { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Filelocation { get; set; }
        public long Filesize { get; set; }
        public DateTime Expiry { get; set; }
        public DateTime Importdate { get; set; }
        public string Metadata1 { get; set; }
        public string Metadata2 { get; set; }
        public string Metadata3 { get; set; }
        public string Metadata4 { get; set; }
        public string Metadata5 { get; set; }
        public string Metadata6 { get; set; }
        public string Metadata7 { get; set; }
        public string Metadata8 { get; set; }
        public string Metadata9 { get; set; }
        public string Tags { get; set; }
        public string Snapshot { get; set; }
        //Used for Q's and Templates etc
        public string UploadStatus { get; set; }
        public int Order { get; set; }
        public string TargetContainerID { get; set; } //target id of the template target (ie a section of the template), default will be fullscreen
        public Boolean Active { get; set; }
    }
}
