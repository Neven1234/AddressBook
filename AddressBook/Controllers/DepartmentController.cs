using AddressBookServices.DTOs;
using AddressBookServices.Implementations;
using AddressBookServices.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim != null)
                {
                    long userId = long.Parse(userIdClaim);
                    return Ok(await _departmentService.GetAllDepartmentAsync(d=>d.userId==userId));
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong " + ex.Message);
            }
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim != null)
                {
                    long userId = long.Parse(userIdClaim);
                    return Ok(await _departmentService.GetDepartmentByIdAsync(id,userId));
                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong " + ex.Message);
            }
        }

        [HttpPost("addNew")]
        public async Task<IActionResult> Add([FromBody] DepartmentDTO department)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim != null)
                {
                    long userId = long.Parse(userIdClaim);
                    department.userId = userId;
                    return Ok(await _departmentService.AddDepartmentAsync(department));
                }

                return Unauthorized();
               
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong " + ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] DepartmentDTO department)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim != null)
                {
                    long userId = long.Parse(userIdClaim);
                    if (userId == department.userId)
                    {
                        await _departmentService.updateDepartmentAsync(department);
                        return Ok(new { message = "Updated successfully" });
                    }

                }
                return Unauthorized();
               
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong " + ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim != null)
                {
                    long userId = long.Parse(userIdClaim);
                    await _departmentService.DeleteDepartmentAsync(id, userId);
                    return Ok(new { message = "Deleted successfully." });
                }

                return Unauthorized();
               
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong " + ex.Message);
            }
        }
    }
}
