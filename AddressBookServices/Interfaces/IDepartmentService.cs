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
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentAsync(Expression<Func<Department, bool>> filter = null);

        Task<DepartmentDTO?> GetDepartmentByIdAsync(int Id,long userId);
        Task updateDepartmentAsync(DepartmentDTO DepartmentDTO);
        Task<DepartmentDTO> AddDepartmentAsync(DepartmentDTO model);
        Task DeleteDepartmentAsync(int Id,long userId);
    }
}
