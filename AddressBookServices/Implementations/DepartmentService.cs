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
    public class DepartmentService:IDepartmentService
    {
        private readonly IGenericRepository<Department, int> _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IGenericRepository<Department, int> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentAsync(Expression<Func<Department, bool>> filter = null)
        {
            return _mapper.Map<List<DepartmentDTO>>( await _repository.GetAllAsync(filter));
        }

        public async Task<DepartmentDTO?> GetDepartmentByIdAsync(int Id, long userId)
        {
            return _mapper.Map<DepartmentDTO>( await _repository.Get(d=>d.Id==Id && d.userId==userId));
        }

        public async Task updateDepartmentAsync(DepartmentDTO department)
        {
            Department updatedDepartment = _mapper.Map<Department>(department);
            await _repository.UpdateAsync(updatedDepartment);
        }

        public async Task<DepartmentDTO> AddDepartmentAsync(DepartmentDTO model)
        {
            Department newDepartment = _mapper.Map<Department>(model);
            return _mapper.Map<DepartmentDTO>( await _repository.AddAsync(newDepartment));
        }

        public async Task DeleteDepartmentAsync(int Id,long userId)
        {
            await _repository.DeleteAsync(Id);
        }
    }
}
