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
    public interface IJobTitleService
    {
        Task<IEnumerable<JobTitleDTO>> GetAllJobTitleAsync(Expression<Func<JobTitle, bool>> filter = null);

        Task<JobTitleDTO?> GetJobTitleByIdAsync(int Id,long userId);
        Task updateJobTitleAsync(JobTitleDTO addressBookDTO);
        Task<JobTitleDTO> AddJobTitleAsync(JobTitleDTO model);
        Task DeleteJobTitleAsync(int Id,long userId);
    }
}
