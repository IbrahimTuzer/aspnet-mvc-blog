using Blog.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Setting>  Settings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDb; Database=AspNetMvcBlogDb;";
            builder.UseSqlServer(connectionString);
            base.OnConfiguring(builder);
        }

        //many to many, N - N Relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasMany(p => p.Categories).WithMany(p => p.Posts);
            base.OnModelCreating(modelBuilder);
        }
    }
}
