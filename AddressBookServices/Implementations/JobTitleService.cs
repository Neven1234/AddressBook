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
    public class JobTitleService:IJobTitleService
    {
        private readonly IGenericRepository<JobTitle, int> _repository;
        private readonly IMapper _mapper;

        public JobTitleService(IGenericRepository<JobTitle, int> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobTitleDTO>> GetAllJobTitleAsync(Expression<Func<JobTitle, bool>> filter = null)
        {
            return _mapper.Map<List<JobTitleDTO>>( await _repository.GetAllAsync(filter));
        }

        public async Task<JobTitleDTO?> GetJobTitleByIdAsync(int Id,long userId)
        {
            return _mapper.Map<JobTitleDTO>( await _repository.Get(j=>j.Id==Id&&j.userId==userId));
        }

        public async Task updateJobTitleAsync(JobTitleDTO jobTitle)
        {
            JobTitle updatedJobTiyle=_mapper.Map<JobTitle>(jobTitle);
            await _repository.UpdateAsync(updatedJobTiyle);
        }

        public async Task<JobTitleDTO> AddJobTitleAsync(JobTitleDTO model)
        {
            JobTitle newJobTiyle = _mapper.Map<JobTitle>(model);
            return _mapper.Map<JobTitleDTO>( await _repository.AddAsync(newJobTiyle));
        }

        public async Task DeleteJobTitleAsync(int Id,long userId)
        {
            var exist=await _repository.Get(j => j.userId == userId&& j.Id==Id);
           if(exist!=null)
                await _repository.DeleteAsync(Id);
        }
    }
}
