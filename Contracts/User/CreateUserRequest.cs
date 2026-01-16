namespace BackApi.Contracts.User
{
    public class CreateUserRequest
    {
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int RoleId { get; set; }
    }
}
