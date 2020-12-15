using MyLinksAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinksAPI.Data
{
    public interface IMyLinksRepository
    {
        public bool SaveChanges();
        public IEnumerable<MyLink> GetMyLinks();
        public MyLink GetMyLink(int id);
        public MyLink GetMyLink(int id, int userId);
        public void CreateMyLink(MyLink myLink);

        public void UpdateMyLink(MyLink myLink);

        public void DeleteMyLink(MyLink myLink);
    }
}
