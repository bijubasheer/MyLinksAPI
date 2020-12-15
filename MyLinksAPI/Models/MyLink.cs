using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinksAPI.Models
{
    public class MyLink
    {
        public int MyLinkId { get; set; }
        public int UserId { get; set; }
        public byte MyLinkGroupTypeId { get; set; }
        public int? ApplicationLarId { get; set; }
        public int? ReportRsId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Sponsor { get; set; }
        public int? SortOrder { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        
        public DateTime? LastModifiedTime { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
