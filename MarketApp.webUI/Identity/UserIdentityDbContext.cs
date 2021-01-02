using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Identity
{
    public class UserIdentityDbContext:IdentityDbContext<UserIdentity>
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options):base(options)
        {

        }
    }
}
