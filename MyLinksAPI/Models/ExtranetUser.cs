using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinksAPI.Models
{
    public class ExtranetUser
    {
        [Key]
        public int UserId { get; set; }
        public string StsUserId { get; set; }
        public string EmailAddress { get; set; }
    }
}
