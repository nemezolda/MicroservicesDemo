﻿using System;

namespace PhoneService.DAL
{
    public class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string [] Roles { get; set; }
    }
}
