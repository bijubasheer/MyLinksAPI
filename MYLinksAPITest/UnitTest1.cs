using System;
using System.Collections;
using Xunit;
using Moq;
using System.Linq;
using MyLinksAPI.Services;
using MyLinksAPI.Data;
using MyLinksAPI.Models;
using System.Collections.Generic;

namespace MYLinksAPITest
{
    public class MyLinksAPIUnitTests
    {
        private readonly Mock<IMyLinksRepository> _mockMyLinksRepository = new Mock<IMyLinksRepository>();
        private readonly Mock<IExtranetUserRepository> _mockExtranetUserRepository = new Mock<IExtranetUserRepository>();
        private readonly IMyLinksService _sut;
        //private readonly Mock<MyLinkDataContext> _myLinkDataContext = new Mock<MyLinkDataContext>();
        public MyLinksAPIUnitTests()
        {
            _sut = new MyLinksService(_mockMyLinksRepository.Object, _mockExtranetUserRepository.Object);
        }
        [Fact]
        public void GetMyLinkTest()
        {
            int id = 29;
            MyLink testLink = new MyLink
            {
                MyLinkId = 29
            };
            _mockMyLinksRepository.Setup(x => x.GetMyLink(id)).Returns(testLink);
            
            var myLink = _sut.GetMyLink(id);
            Assert.Equal(id, myLink.MyLinkId);
        }

        [Fact]
        public void GetMyLinksTest()
        {
            int id = 29;
            MyLink testLink = new MyLink
            {
                MyLinkId = 29
            };
            List<MyLink> myTestLinks = new List<MyLink>();
            myTestLinks.Add(testLink);
            _mockMyLinksRepository.Setup(x => x.GetMyLinks()).Returns(myTestLinks);

            var myLinks = _sut.GetMyLinks().ToList<MyLink>();
            
            Assert.Single(myLinks);
        }

        [Fact]
        public void AddNewLinkTest()
        {
            MyLink testLink = new MyLink
            {
                MyLinkId = 29
            };
            List<MyLink> myTestLinks = new List<MyLink>();
            myTestLinks.Add(testLink);
            bool result = true;
            _mockMyLinksRepository.Setup(x => x.CreateMyLink(testLink));
            _mockMyLinksRepository.Setup(x => x.SaveChanges()).Returns(result);

            Assert.True(result);
        }
    }
}
