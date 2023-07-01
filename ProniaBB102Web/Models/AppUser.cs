﻿using Microsoft.AspNetCore.Identity;

namespace ProniaBB102Web.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsReminded { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public List<Order> Orders { get; set; }


    }
}
