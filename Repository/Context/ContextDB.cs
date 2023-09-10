using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<UserEntity> UsersTable { get; set; }

        public DbSet<LoginEntity> LoginTable { get; set; }
    }
}
