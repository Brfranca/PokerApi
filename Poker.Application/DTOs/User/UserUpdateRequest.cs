namespace Poker.Service.DTOs.User
{
    public class UserUpdateRequest
    {
        public int Id { get; set; } 
        public string? Password { get; set; }
        public string? Name { get; set; }
    }
}
