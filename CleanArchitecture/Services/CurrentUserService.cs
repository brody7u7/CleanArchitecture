using $ext_safeprojectname$.Core.Models;
using $ext_safeprojectname$.Core.Policies;
using System.Security.Claims;

namespace $ext_safeprojectname$.API.Services
{
    public class CurrentUserService : Core.Interfaces.ICurrentUserService
    {
        private readonly ClaimsPrincipal _claimsPrincipal;

        private long? _userId;
        private string? _user;
        private string? _email;
        private string? _roleName;
        private Role _role;

        public CurrentUserService(IHttpContextAccessor accessor)
        {
            _claimsPrincipal = accessor.HttpContext?.User
                ?? throw new Exception("Expected ClaimsPrincipal");
        }

        public long? UserID
        {
            get
            {
                if (_userId.HasValue) return _userId.Value;
                var claim = _claimsPrincipal.FindFirst(Claims.ClaimId);
                if (claim == null) throw new Exception("Could not locate UserID claim");
                _userId = int.Parse(claim.Value);

                return _userId.Value;
            }
        }
        public string? User
        {
            get
            {
                if (!string.IsNullOrEmpty(_user)) return _user;
                var claim = _claimsPrincipal.FindFirst(Claims.ClaimUser);
                if (claim == null) throw new Exception("Could not locate User claim");
                _user = claim.Value;

                return _user;
            }
        }

        public string? Email
        {
            get
            {
                if (!string.IsNullOrEmpty(_email)) return _email;
                var claim = _claimsPrincipal.FindFirst(Claims.ClaimEmail);
                if (claim == null) throw new Exception("Could not locate Email claim");
                _email = claim.Value;

                return _email;
            }
        }

        public string? RoleName
        {
            get
            {
                if (!string.IsNullOrEmpty(_roleName)) return _roleName;
                var claim = _claimsPrincipal.FindFirst(Claims.ClaimRole);
                if (claim == null) throw new Exception("Could not locate RoleName claim");
                _roleName = claim.Value;

                return _roleName;
            }
        }

        public Role Role
        {
            get
            {
                if (_role != Role.None) return _role;
                switch (RoleName)
                {
                    case Roles.Administrator: _role = Role.Administrator; break;
                }

                return _role;
            }
        }
    }
}
