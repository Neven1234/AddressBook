using AddressBookServices.DTOs;
using AddressBookServices.Implementations;
using AddressBookServices.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AddressBookController : ControllerBase
    {
        private readonly IAddressBookService _addressBookService;

        public AddressBookController(IAddressBookService addressBookService)
        {
          _addressBookService = addressBookService;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll() {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim != null)
                {
                    long userId = long.Parse(userIdClaim);
                    return Ok(await _addressBookService.GetAllAddreassBookAsync(a=>a.UserId==userId));
                }

                return Unauthorized();

            }
            catch (Exception ex) { 
                return BadRequest("Something went wrong "+ex.Message);
            }
        }
        [HttpGet("getById/{Id}")]
        public async Task<IActionResult>GetById(long Id)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim != null)
                {
                    long userId = long.Parse(userIdClaim);
                    return Ok(await _addressBookService.GetAddressBookByIdAsync(Id, userId));
                }

                return Unauthorized();

            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong " + ex.Message);
            }
        }
        [HttpPost("addNew")]
        public async Task<IActionResult> Add([FromForm] AddOrEditAddreassBookDTO model)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null) return Unauthorized();
                long userId = long.Parse(userIdClaim);

                model.userId = userId; 

                if (model.PhotoFile != null)
                {
                    
                    var photoPath = await SavePhotoAsync(model.PhotoFile);
                    model.Photo = photoPath;
                }

                var result = await _addressBookService.AddAddressBookAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong " + ex.Message);
            }
        }

        [HttpPut("updated")]
        public async Task<IActionResult> Update(AddOrEditAddreassBookDTO dto)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim != null)
                {
                    long userId = long.Parse(userIdClaim);
                    if(userId==dto.userId)
                    {
                        if (dto.PhotoFile != null)
                        {

                            var photoPath = await SavePhotoAsync(dto.PhotoFile);
                            dto.Photo = photoPath;
                        }
                        await _addressBookService.updateAddressBookAsync(dto);
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
        [HttpDelete("delete/{Id}")]
        public async Task<IActionResult>Delete(long Id)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim != null)
                {
                    long userId = long.Parse(userIdClaim);
                    await _addressBookService.DeleteAddreasBookAsync(Id,userId);
                    return Ok(new { message = "Deleted successfully." });
                }

                return Unauthorized();
                

            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong " + ex.Message);
            }
        }
        // for image updload
        private async Task<string> SavePhotoAsync(IFormFile photoFile)
        {
            if (photoFile == null || photoFile.Length == 0)
                return null;
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photoFile.FileName);
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photoFile.CopyToAsync(stream);
            }

            
            return $"/uploads/{fileName}";
        }

    }
}
