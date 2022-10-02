using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MewaAppBackend.WebApi.Extentions
{
    public static class CurrentUserExtension
    {
        public static string? GetUserGuidFromRequest(this ControllerBase controllerBase)
        {
            return controllerBase.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
