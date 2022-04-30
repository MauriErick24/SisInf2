using core.Communication;
using interfaces.Repositories;
using interfaces.Services;
using models;
using System;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace core.Services
{ 
    public class UserService : IUserService<AppResponse<UserAuthenticated>>
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AppResponse<UserAuthenticated>> Login(UserPassword user)
        {
            if (user.Username == null && user.Password == null)
                return new AppResponse<UserAuthenticated>("Invalid Account");

            var userAuthenticated = await _userRepository.GetByEmail(user.Username);
            
            if (userAuthenticated == null)
                return new AppResponse<UserAuthenticated>("Invalid Account");

            if (user.Password == userAuthenticated.Password)
            {
                var username = userAuthenticated.Name + " " + userAuthenticated.Lastname;
                var userToken = new UserAuthenticated
                {
                    Token = GenerateToken(userAuthenticated),
                    UserId = userAuthenticated.Id,
                    Username = username,
                    Email = userAuthenticated.Email
                };
                return new AppResponse<UserAuthenticated>(userToken);
            }
            else
            {
                return new AppResponse<UserAuthenticated>("Invalid Account");
            }
        }

        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Constants.SecretWord);
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim(ClaimTypes.GivenName, user.Name + user.Lastname),
                new Claim(ClaimTypes.Email, user.Email)
            };
            var claim = new ClaimsIdentity();
            claim.AddClaims(claims);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claim,
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
