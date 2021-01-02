using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Identity
{
    public class UserIdentity:IdentityUser
    {
        public string FullName { get; set; } //Ekstra istediğimiz özellik
    }
}
