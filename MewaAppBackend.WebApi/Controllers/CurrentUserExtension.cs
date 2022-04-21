using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace MewaAppBackend.WebApi.Controllers
{
    public static class CurrentUserExtension
    {
        public static string GetUserGuidFromRequest(this ControllerBase controllerBase)
        {
            controllerBase.Request.Headers.TryGetValue("Authorization", out var headerValue);

            var token = headerValue.Count > 0 ? headerValue[0] : null;
            if (token == null)
            {
                return null;
            }
            var deserializedToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            var claim = deserializedToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.UniqueName);
            return claim.Value;
        }
    }
}
