using AddressBookServices.DTOs;
using AddressBookServices.Implementations;
using AddressBookServices.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitleController : ControllerBase
    {
        private readonly IJobTitleService _jobTitleService;

        public JobTitleController(IJobTitleService jobTitleService)
        {
            _jobTitleService = jobTitleService;
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
                    return Ok(await _jobTitleService.GetAllJobTitleAsync(j=>j.userId==userId));
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
                    return Ok(await _jobTitleService.GetJobTitleByIdAsync(id,userId));
                }

                return Unauthorized();
                
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong " + ex.Message);
            }
        }

        [HttpPost("addNew")]
        public async Task<IActionResult> Add([FromBody] JobTitleDTO jobTitle)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim != null)
                {
                    long userId = long.Parse(userIdClaim);
                    jobTitle.userId = userId;
                    return Ok(await _jobTitleService.AddJobTitleAsync(jobTitle));
                }

                return Unauthorized();

               
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong " + ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] JobTitleDTO jobTitle)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim != null)
                {
                    long userId = long.Parse(userIdClaim);
                    if (userId == jobTitle.userId)
                    {
                        await _jobTitleService.updateJobTitleAsync(jobTitle);
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
                    await _jobTitleService.DeleteJobTitleAsync(id,userId);
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
