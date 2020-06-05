using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
  public class CodenationContext : DbContext
  {
    public DbSet<Company> Companies { get; set; }
    public DbSet<Acceleration> Accelerantions { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<Submission> Submissions { get; set; }
    public DbSet<User> Users { get; set; }

    public CodenationContext()
    {

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //  ---------------------
      //  FLUENT API
      //  ---------------------

      // ACCELERATION
      // --- Primary Key
      modelBuilder.Entity<Acceleration>().HasKey(a => a.Id);

      // --- Properties
      modelBuilder.Entity<Acceleration>().Property(a => a.Name).HasMaxLength(100).IsRequired();
      modelBuilder.Entity<Acceleration>().Property(a => a.Slug).HasMaxLength(50).IsRequired();
      modelBuilder.Entity<Acceleration>().Property(a => a.CreatedAt).IsRequired();


      // CANDIDATE
      // --- Composite Keys
      modelBuilder.Entity<Candidate>()
                .HasKey(k => new { k.UserId, k.CompanyId, k.AccelerationId});

      // --- Foreign Keys
      modelBuilder.Entity<Candidate>()
                .HasOne<User>(u => u.User)
                .WithMany(c => c.Candidates)
                .HasForeignKey(u => u.UserId);

      modelBuilder.Entity<Candidate>()
          .HasOne<Acceleration>(a => a.Acceleration)
          .WithMany(c => c.Candidates)
          .HasForeignKey(a => a.AccelerationId);

      modelBuilder.Entity<Candidate>()
          .HasOne<Company>(c => c.Company)
          .WithMany(c => c.Candidates)
          .HasForeignKey(c => c.CompanyId);

      // --- Properties
      modelBuilder.Entity<Candidate>().Property(c => c.Status).IsRequired();
      modelBuilder.Entity<Candidate>().Property(c => c.CreatedAt).IsRequired();


      // CHALLENGE
      // --- Primary Key
      modelBuilder.Entity<Challenge>().HasKey(c => c.Id);

      // --- Properties
      modelBuilder.Entity<Challenge>().Property(c => c.Name).HasMaxLength(100).IsRequired();
      modelBuilder.Entity<Challenge>().Property(c => c.Slug).HasMaxLength(50).IsRequired();
      modelBuilder.Entity<Challenge>().Property(c => c.CreatedAt).IsRequired();

      
      // COMPANY
      //  --- Primary Key
      modelBuilder.Entity<Company>().HasKey(c => c.Id);
      
      // --- Properties
      modelBuilder.Entity<Company>().Property(c => c.Name).HasMaxLength(100).IsRequired();
      modelBuilder.Entity<Company>().Property(c => c.Slug).HasMaxLength(50).IsRequired();
      modelBuilder.Entity<Company>().Property(c => c.CreatedAt).IsRequired();

      
      // SUBMISSION
      // --- Composite Keys
      modelBuilder.Entity<Submission>()
                .HasKey(k => new { k.ChallengeId, k.UserId});

      // --- Foreign Keys
      modelBuilder.Entity<Submission>()
        .HasOne<User>(u => u.User)
        .WithMany(s => s.Submissions)
        .HasForeignKey(u => u.UserId);

      modelBuilder.Entity<Submission>()
        .HasOne<Challenge>(c => c.Challenge)
        .WithMany(s => s.Submissions)
        .HasForeignKey(c => c.ChallengeId);

      // --- Properties
      modelBuilder.Entity<Submission>().Property(s => s.Score).IsRequired();
      modelBuilder.Entity<Submission>().Property(s => s.CreatedAt).IsRequired();

      
      // USER
      //  --- Primary Key
      modelBuilder.Entity<User>().HasKey(u => u.Id);

      // --- Properties
      modelBuilder.Entity<User>().Property(u => u.FullName).HasMaxLength(100).IsRequired();
      modelBuilder.Entity<User>().Property(u => u.Email).HasMaxLength(100).IsRequired();
      modelBuilder.Entity<User>().Property(u => u.NickName).HasMaxLength(50).IsRequired();
      modelBuilder.Entity<User>().Property(u => u.Password).HasMaxLength(255).IsRequired();
      modelBuilder.Entity<User>().Property(u => u.CreatedAt).IsRequired();
    }
  }
}