using AddressBookRepository.Repository;
using AddressBookServices.DTOs;
using AddressBookServices.Interfaces;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookServices.Implementations
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IGenericRepository<AddressBookModel, long> _repository;
        private readonly IMapper _mapper;

        public AddressBookService(IGenericRepository<AddressBookModel,long> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetAddressBookDTO> AddAddressBookAsync(AddOrEditAddreassBookDTO model)
        {
           AddressBookModel newAddressBook=_mapper.Map<AddressBookModel>(model);
            return _mapper.Map<GetAddressBookDTO>(await _repository.AddAsync(newAddressBook));
        }

        public async Task DeleteAddreasBookAsync(long Id, long userId)
        {
            var deletedAddress=await _repository.Get(a=>a.Id==Id && a.UserId==userId);
            if (deletedAddress == null) throw new Exception("Unauthorized");
            await _repository.DeleteAsync(Id);
        }

        public async Task<GetAddressBookDTO?> GetAddressBookByIdAsync(long Id,long userId)
        {
            AddressBookModel addressBookModel = await _repository.GetByIdAsync(Id);
            if (addressBookModel.UserId!=userId)
            {
                throw new Exception("Unauthorized");
            }
            return _mapper.Map<GetAddressBookDTO>(addressBookModel);
        }

        public async Task<IEnumerable<GetAddressBookDTO>> GetAllAddreassBookAsync(Expression<Func<AddressBookModel, bool>> filter = null)
        {
            return _mapper.Map<List<GetAddressBookDTO>>(await _repository.GetAllAsync(filter));
        }

        public async Task updateAddressBookAsync(AddOrEditAddreassBookDTO addressBookDTO)
        {
            AddressBookModel updatedAddressBook = _mapper.Map<AddressBookModel>(addressBookDTO);
            await _repository.UpdateAsync(updatedAddressBook);
        }
    }
}
