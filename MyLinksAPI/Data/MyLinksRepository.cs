using MyLinksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinksAPI.Data
{
    public class MyLinksRepository : IMyLinksRepository
    {
        private readonly MyLinkDataContext _context;

        public MyLinksRepository(MyLinkDataContext context)
        {
            _context = context;
        }

        public void CreateMyLink(MyLink myLink)
        {
            if (myLink == null)
                throw new ArgumentException(nameof(myLink));

            myLink.CreatedTime = DateTime.Now;
            _context.MyLinks.Add(myLink);
        }

        public void DeleteMyLink(MyLink myLink)
        {
            _context.Remove(myLink);
        }

        public MyLink GetMyLink(int id)
        {
            MyLink result = _context.MyLinks.FirstOrDefault(p => p.MyLinkId == id);

            return result;
        }

        public MyLink GetMyLink(int id, int userId)
        {
            MyLink result = _context.MyLinks.FirstOrDefault(p => p.MyLinkId == id && p.UserId == userId);

            return result;
        }

        public IEnumerable<MyLink> GetMyLinks()
        {
            return _context.MyLinks.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMyLink(MyLink myLink)
        {
            _context.Update(myLink);
        }
    }
}
