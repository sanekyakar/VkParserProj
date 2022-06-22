using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Models.Database.UserAccount> UserAccounts { get; set; }

        public DbSet<Models.Database.AuthTokenVk> TokenVk { get; set; }

        public DbSet<Models.Database.VkEntities.GroupVkDatabase> Groups { get; set; }
        public DbSet<Models.Database.IntermediateProp.City> Cities { get; set; }
        public DbSet<Models.Database.IntermediateProp.Country> Countries { get; set; }
        public DbSet<Models.Database.IntermediateProp.LastSeen> LastSeens { get; set; }
        public DbSet<Models.Database.IntermediateProp.RelationPartner> RelationPartners { get; set; }
        public DbSet<Models.Database.IntermediateProp.Relative> Relatives { get; set; }
        public DbSet<Models.Database.IntermediateProp.School> Schools { get; set; }
        public DbSet<Models.Database.IntermediateProp.University> Universities { get; set; }

        public DbSet<Models.Database.VkEntities.FriendsVk> FriendsVks { get; set; }
        public DbSet<Models.Database.VkEntities.Members> Members { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Vk.db");
        }
    }
}