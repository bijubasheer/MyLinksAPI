using MyLinksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinksAPI.Data
{
    public class MockMyLinksRepository : IMyLinksRepository
    {
        public void CreateMyLink(MyLink myLink)
        {
            throw new NotImplementedException();
        }

        public void DeleteMyLink(MyLink myLink)
        {
            throw new NotImplementedException();
        }

        public MyLink GetMyLink(int id)
        {
            MyLink myLink = new MyLink();
            myLink.MyLinkId = 199;
            myLink.Name = "My first Link";
            return myLink;
        }

        public MyLink GetMyLink(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MyLink> GetMyLinks()
        {
            return new List<MyLink>
            { 
                new MyLink{MyLinkId=1, Name = "My First Link", UserId = 10},
                new MyLink{MyLinkId=2, Name = "My Second Link", UserId = 20},
                new MyLink{MyLinkId=3, Name = "My Third Link", UserId = 30}
            };
            
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateMyLink(MyLink myLink)
        {
            throw new NotImplementedException();
        }
    }
}
