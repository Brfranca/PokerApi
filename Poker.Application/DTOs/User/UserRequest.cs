﻿namespace Poker.Service.DTOs.User
{
    public class UserRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Name { get; set; }
    }
}
