using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinksAPI.DTOs
{
    public class MyLinkCreateDTO
    {
        //public int MyLinkId { get; set; }
        //[Required]
        //public int UserId { get; set; }
        [Required] 
        public byte MyLinkGroupTypeId { get; set; }
        public int? ApplicationLarId { get; set; }
        public int? ReportRsId { get; set; }
        [Required] 
        public string Url { get; set; }
        [Required] 
        public string Name { get; set; }
        public string Sponsor { get; set; }
        public int? SortOrder { get; set; }
        [Required] 
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        [Required]
        public string NameId { get; set; }
        //[Timestamp]
        //public byte[] RowVersion { get; set; }
    }
}
