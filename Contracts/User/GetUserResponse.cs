namespace BackApi.Contracts.User
{
    public class GetUserResponse
    {
        public int UserId { get; set; }
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int RoleId { get; set; }
    }
}