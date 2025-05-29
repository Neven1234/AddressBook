using AddressBookServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookServices.Interfaces
{
    public interface IUserService
    {
        Task Regist(RegistDTO registerDTO);
        Task<string> LogIn(LogInDto logInDTO);
    }
}
