using AddressBookServices.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookServices.Interfaces
{
    public interface IAddressBookService
    {
        Task<IEnumerable<GetAddressBookDTO>> GetAllAddreassBookAsync(Expression<Func<AddressBookModel, bool>> filter = null);

        Task<GetAddressBookDTO?> GetAddressBookByIdAsync(long Id, long userId);
        Task updateAddressBookAsync(AddOrEditAddreassBookDTO addressBookDTO);
        Task<GetAddressBookDTO> AddAddressBookAsync(AddOrEditAddreassBookDTO model);
        Task DeleteAddreasBookAsync(long Id,long userId);
    }
}
