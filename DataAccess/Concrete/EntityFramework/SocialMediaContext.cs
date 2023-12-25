using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class SocialMediaContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SocialMedia;Trusted_Connection=true;TrustServerCertificate=true");
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Fav> Favs { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<UserReport> UserReports { get; set; }
        public DbSet<UserChat> UsersChats { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

    }
}
