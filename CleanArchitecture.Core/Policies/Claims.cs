using System.Security.Claims;

namespace $ext_safeprojectname$.Core.Policies
{
    public static class Claims
    {
        public const string ClaimId = ClaimTypes.NameIdentifier;
        public const string ClaimUser = ClaimTypes.Name;
        public const string ClaimEmail = ClaimTypes.Email;
        public const string ClaimRole = ClaimTypes.Role;
    }
}
