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
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<RegistDTO, User>();
            
        }
    }
}
