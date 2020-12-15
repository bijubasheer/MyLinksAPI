using MyLinksAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinksAPI.Data
{
    public interface IExtranetUserRepository
    {
        public IEnumerable<ExtranetUser> GetExtranetUsers();
        public ExtranetUser GetExtranetUser(int id);
        public ExtranetUser GetExtranetUser(string stsUserId);
    }
}
