using MyLinksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinksAPI.Data
{
    public class ExtranetUserRepository : IExtranetUserRepository
    {
        private readonly MyLinkDataContext _context;

        public ExtranetUserRepository(MyLinkDataContext context)
        {
            _context = context;
        }
        public ExtranetUser GetExtranetUser(int id)
        {
            return _context.ExtranetUsers.FirstOrDefault(u => u.UserId == id);
        }

        public ExtranetUser GetExtranetUser(string stsUserId)
        {
            return _context.ExtranetUsers.FirstOrDefault(u => u.StsUserId == stsUserId);
        }

        public IEnumerable<ExtranetUser> GetExtranetUsers()
        {
            return _context.ExtranetUsers;
        }
    }
}
