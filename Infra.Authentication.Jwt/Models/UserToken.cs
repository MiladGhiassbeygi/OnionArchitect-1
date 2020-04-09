﻿using System;


namespace Infra.Authentication.Jwt.Models
{
    public class UserToken
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
