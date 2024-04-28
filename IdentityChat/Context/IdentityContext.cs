using IdentityChat.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityChat.Context
{
    public class IdentityContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ATMACA\\SQLEXPRESS; database=DbIdentityChat; Integrated security = true; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>().HasOne(x => x.Sender)
                .WithMany(y => y.Senders)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Message>().HasOne(x => x.Receiver)
                .WithMany(y => y.Receivers)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Draft>().HasOne(x => x.SenderDraft)
                .WithMany(y => y.SenderDrafts)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Draft>().HasOne(x => x.ReceiverDraft)
                .WithMany(y => y.ReceiverDrafts)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(builder);
        }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Draft> Drafts { get; set; }
        public DbSet<Trash> Trashes { get; set; }
    }
}
