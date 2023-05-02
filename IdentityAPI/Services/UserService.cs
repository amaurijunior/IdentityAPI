using AutoMapper;
using IdentityAPI.Data.DTOs;
using IdentityAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityAPI.Services
{
    public class UserService { 
        private  IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _singInManager;
        private TokenService _tokenService;

        public UserService(UserManager<User> userManager, IMapper mapper, SignInManager<User> singInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _singInManager = singInManager;
            _tokenService = tokenService;
        }

        public async Task<IdentityResult> CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException("Não foi possivel castrar Usuario");
            }

            return result;
        
        }

        public async Task<string> Login(UserLoginDTO Login)
        {
            var login =  await _singInManager.PasswordSignInAsync(Login.UserName, Login.Password, false, false);

            if (!login.Succeeded)
            {
                throw new ApplicationException("Não foi possivel autenticar o Usário.");
            }
            var user = _singInManager.UserManager.Users.FirstOrDefault(x => x.NormalizedUserName == Login.UserName.ToUpper());

           var result =  _tokenService.GenerateToken(user);

            return result;
        }
    }
}
