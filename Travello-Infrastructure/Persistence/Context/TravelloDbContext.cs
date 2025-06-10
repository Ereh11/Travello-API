using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Travello_Domain;

namespace Travello_Infrastructure.Persistence;

public class TravelloDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    public DbSet<Passport> Passports { get; set; }
    public DbSet<HotelImage> HotelImages { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<UserOffer> UserOffers { get; set; }
    public DbSet<UserReview> UserReviews { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Accommodation> Accommodations { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<HotelFacility> HotelFacilities { get; set; }
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Refund> Refunds { get; set; }

    public DbSet<ProfileImage> Images { get; set; }
    public TravelloDbContext(DbContextOptions<TravelloDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(TravelloDbContext).Assembly
            );
    }
}
