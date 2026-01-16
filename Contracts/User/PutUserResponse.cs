namespace BackApi.Contracts.User
{
    public class PutUserResponse
    {
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int RoleId { get; set; }
    }
}
