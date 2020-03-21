using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TEST.PROJECT;

namespace TEST.REPP
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option):base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<User>());
            new UserProfileMap(modelBuilder.Entity<UserProfile>());

        }
    }
}
