namespace CleanArchitecture.Core.Interfaces
{
    public interface ICurrentUserService
    {
        public long? UserID { get; }
        public string? User { get; }
        public string? Email { get; }
        public string? RoleName { get; }
        public Models.Role Role { get; }
    }
}
