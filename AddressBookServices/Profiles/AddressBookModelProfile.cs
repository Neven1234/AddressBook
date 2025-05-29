using AddressBookServices.DTOs;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookServices.Profiles
{
    public class AddressBookModelProfile:Profile
    {
        public AddressBookModelProfile()
        {
            CreateMap<AddressBookModel, GetAddressBookDTO>().ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
                DateTime.Today.Year - src.DateOfBirth.Year -
                (DateTime.Today.DayOfYear < src.DateOfBirth.DayOfYear ? 1 : 0)));
            CreateMap<AddOrEditAddreassBookDTO, AddressBookModel>();
                
        }
    }
}
