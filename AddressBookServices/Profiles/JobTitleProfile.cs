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
    public class JobTitleProfile:Profile
    {
        public JobTitleProfile()
        {
            CreateMap<JobTitle,JobTitleDTO>().ReverseMap();
        }
    }
}
