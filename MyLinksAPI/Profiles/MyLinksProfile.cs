using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLinksAPI.Models;
using MyLinksAPI.DTOs;

namespace MyLinksAPI.Profiles
{
    public class MyLinksProfile:Profile
    {
        public MyLinksProfile()
        {
            // Source -> Destination
            CreateMap<MyLink, MyLinkReadDTO>();

            CreateMap<MyLinkCreateDTO, MyLink>();

            CreateMap<MyLinkUpdateDTO, MyLink>();
        }
    }
}
