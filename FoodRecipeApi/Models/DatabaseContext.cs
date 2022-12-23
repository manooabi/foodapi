using Microsoft.EntityFrameworkCore;

namespace FoodRecipeApi.Models
{
    public partial class DatabaseContext:DbContext
    {

        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Users>? Users { get; set; }
        public virtual DbSet<Foods>? Foods { get; set; }
        public virtual DbSet<Saved>? Saved { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                
                entity.ToTable("Users");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.UserName).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(50).IsUnicode(false);
              
            });

            modelBuilder.Entity<Foods>(entity =>
            {
                entity.ToTable("Foods");
                entity.Property(e => e.FoodId).HasColumnName("FoodId");
                entity.Property(e => e.FoodName).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Categories).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Type).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Photo).HasMaxLength(555).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(555).IsUnicode(false);
                entity.Property(e => e.Indegredients).HasMaxLength(555).IsUnicode(false);
               
            });
            modelBuilder.Entity<Saved>(entity =>
            {
                entity.ToTable("Saved");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.FoodId).HasColumnName("FoodId");
                entity.Property(e => e.FoodName).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Photo).HasMaxLength(555).IsUnicode(false);
               

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
