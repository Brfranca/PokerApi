﻿namespace Poker.Domain.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
    }
}
