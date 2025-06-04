using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.DBContext
{
    public class VoiceDBContext:DbContext
    {
        public VoiceDBContext(DbContextOptions<VoiceDBContext> options) : base(options)
        {

        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomChat> RoomChats { get; set; }
        public DbSet<UserConnection> UserConnections { get; set; }
        public DbSet<VoiceCalling> VoiceCallings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VoiceCalling>()
                .HasOne(vc => vc.Caller)
                .WithMany(u => u.CallsMade)
                .HasForeignKey(vc => vc.CallerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VoiceCalling>()
                .HasOne(vc => vc.Receiver)
                .WithMany(u => u.CallsReceived)
                .HasForeignKey(vc => vc.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
