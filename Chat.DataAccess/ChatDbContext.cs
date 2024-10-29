using Chat.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;


namespace Chat.DataAccess;

public class ChatDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<BanEntity> Clubs { get; set; }
    public DbSet<MessageEntity> Trainers { get; set; }

    public ChatDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();

        modelBuilder.Entity<MessageEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<MessageEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<MessageEntity>().HasOne(x => x.User)
            .WithMany(x => x.Messages)
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<BanEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<BanEntity>().HasIndex(x => x.ExternalId).IsUnique();
        modelBuilder.Entity<BanEntity>().HasOne(x => x.User)
            .WithOne(x => x.Ban)
            .HasForeignKey<BanEntity>(x => x.UserId);
    }
}