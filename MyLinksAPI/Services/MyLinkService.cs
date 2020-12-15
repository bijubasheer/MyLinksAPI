using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLinksAPI.Models;
using MyLinksAPI.Data;

namespace MyLinksAPI.Services
{
    public class MyLinksService : IMyLinksService
    {
        private readonly IExtranetUserRepository _extranetUserRepository;
        private readonly IMyLinksRepository _myLinksRepository;

        public MyLinksService(IMyLinksRepository myLinksRepository, IExtranetUserRepository extranetUserRepository)
        {
            _extranetUserRepository = extranetUserRepository;
            _myLinksRepository = myLinksRepository;
        }
        

        public void DeleteMyLink(MyLink myLink)
        {
            _myLinksRepository.DeleteMyLink(myLink);
        }

        public MyLink GetMyLink(int id)
        {
            return _myLinksRepository.GetMyLink(id);
        }

        public MyLink GetMyLink(int id, string stsUserId)
        {
            ExtranetUser user = _extranetUserRepository.GetExtranetUser(stsUserId);
            if (user == null) return null;

            return _myLinksRepository.GetMyLink(id, user.UserId);
        }

        public IEnumerable<MyLink> GetMyLinks()
        {
            List<ExtranetUser> extranetUsers = _extranetUserRepository.GetExtranetUsers().ToList<ExtranetUser>();
            return _myLinksRepository.GetMyLinks();
        }

        public bool SaveChanges()
        {
            return _myLinksRepository.SaveChanges();
        }

        public void UpdateMyLink(MyLink myLink)
        {
            _myLinksRepository.UpdateMyLink(myLink);
        }

        void IMyLinksService.CreateMyLink(MyLink myLink, string nameId)
        {
            ExtranetUser user = _extranetUserRepository.GetExtranetUser(nameId);
            if (user == null)
                throw new NullReferenceException();

            myLink.UserId = user.UserId;
            _myLinksRepository.CreateMyLink(myLink);
        }
    }
}
