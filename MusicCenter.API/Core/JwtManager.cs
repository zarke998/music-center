using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MusicCenter.EfDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.API.Core
{
    public class JwtManager
    {
        private readonly MusicCenterDbContext _context;
        private readonly string _issuer;
        private readonly string _secretKey;

        public JwtManager(MusicCenterDbContext context, string issuer, string secretKey)
        {
            _issuer = issuer;
            _secretKey = secretKey;
            _context = context;
        }

        public string MakeToken(string email, string password)
        {
            var user = _context.Users.Include(u => u.UseCases)
                                    .Where(u => u.Email == email &&
                                        u.Password == password &&
                                        u.IsActive == true).FirstOrDefault();

            if(user == null)
            {
                return null;
            }

            var jwtActor = new JwtActor()
            {
                Id = user.Id,
                Identity = user.Email,
                AllowedUseCases = user.UseCases.Select(useCase => useCase.UseCaseId).ToList()
            };

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "music_center_api", ClaimValueTypes.String, _issuer),
                new Claim("UserId", user.Id.ToString(), ClaimValueTypes.Integer64, _issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(jwtActor), ClaimValueTypes.String, _issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken
            (
                issuer: _issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
