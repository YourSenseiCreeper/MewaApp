using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MewaAppBackend.Services.User
{
    public class UserCreationService : IUserCreationService
    {
        private readonly SignInManager<Model.Model.User> _signInManager;

        private readonly IConfiguration _configuration;

        protected readonly UserManager<Model.Model.User> _userManager;

        public UserCreationService(
            UserManager<Model.Model.User> userManager,
            SignInManager<Model.Model.User> signInManager,
            IConfiguration configuration)
        {
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<string?> HandleLogin(string email, string password)
        {
            SignInResult loginResoult;
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return null;

            loginResoult = await _signInManager.PasswordSignInAsync(user, password, false, false);

            if (loginResoult.Succeeded)
            {
                var claims = GenerateClaims(user);

                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddDays(2),
                    GenerateSigningCredential()
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return null;
        }

        private SigningCredentials GenerateSigningCredential()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

        private Claim[] GenerateClaims(Model.Model.User user)
        {
            return new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id)
            };
        }

        public async Task<IdentityResult> HandleRegister(Model.Model.User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
    }
}
