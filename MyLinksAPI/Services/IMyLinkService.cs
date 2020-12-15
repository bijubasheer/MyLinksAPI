using MyLinksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinksAPI.Services
{
    public interface IMyLinksService
    {
        public bool SaveChanges();
        public IEnumerable<MyLink> GetMyLinks();
        public MyLink GetMyLink(int id);
        public MyLink GetMyLink(int id, string nameId);
        public void CreateMyLink(MyLink myLink, string nameId);

        public void UpdateMyLink(MyLink myLink);

        public void DeleteMyLink(MyLink myLink);
    }
}
