using AddressBookRepository.Repository;
using AddressBookServices.DTOs;
using AddressBookServices.Interfaces;
using AutoMapper;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookServices.Implementations
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User, long> _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User,long> repository, 
            IConfiguration configuration,IMapper mapper)
        {
          _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<string> LogIn(LogInDto logInDTO)
        {
            var user = await _repository.Get(u => u.UserName == logInDTO.UserName);
            var hashedInputPassword = HashPassword(logInDTO.Password);
            if (user == null || user.Password != hashedInputPassword)
                throw new Exception("username or password are wrong");
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = getToken(authClaims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task Regist(RegistDTO registerDTO)
        {     var userExist=await _repository.Get(u=>u.UserName== registerDTO.UserName);
            if (userExist == null)
            {
                registerDTO.Password = HashPassword(registerDTO.Password);
                User regesteredUser = _mapper.Map<User>(registerDTO);
                await _repository.AddAsync(regesteredUser);
            }
            else
            {
                throw new Exception("username already exist");
            }

        }
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
        private JwtSecurityToken getToken(List<Claim> authClims)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: this._configuration["JWT:ValidIssuer"],
                audience: this._configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );
            return token;

        }
    }
}
