using Microsoft.EntityFrameworkCore;

namespace WorkForceManagement.Models
{
    public class SQLiteDBContext : DbContext
    {
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Skillmaps> Skillmaps { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SoftLock> SoftLocks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source='data.db'");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureModels(modelBuilder);
        }

        private static void ConfigureModels(ModelBuilder modelBuilder)
        {

            #region Entity: Employees
            modelBuilder.Entity<Employees>()
                .ToTable("Employees");
            modelBuilder.Entity<Employees>()
                .Property(x => x.employee_name)
                .IsRequired().HasMaxLength(50)
                .HasColumnType("varchar");
            modelBuilder.Entity<Employees>()
                .Property(x => x.status).IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");
            modelBuilder.Entity<Employees>()
                .Property(x => x.manager)
                .HasMaxLength(30)
                .HasColumnType("varchar");
            modelBuilder.Entity<Employees>()
                .Property(x => x.wfm_manager)
                .HasMaxLength(30)
                .HasColumnType("varchar");
            modelBuilder.Entity<Employees>()
                .Property(x => x.email)
                .HasColumnType("varchar")
                .HasMaxLength(100);
            modelBuilder.Entity<Employees>()
                .Property(x => x.lockstatus)
                .HasMaxLength(30)
                .HasColumnType("varchar");
            modelBuilder.Entity<Employees>()
                .Property(x => x.experience)
                .HasColumnType("decimal(5,0)");
            #endregion

            #region Entity: Skills
            modelBuilder.Entity<Skills>()
                .ToTable("Skills");
            modelBuilder.Entity<Skills>()
                .Property(x => x.skillname)
                .IsRequired().HasMaxLength(30)
                .HasColumnType("varchar");
            #endregion

            #region Entity: Skillmaps
            modelBuilder.Entity<Skillmaps>()
                .ToTable("Skillmaps");
            modelBuilder.Entity<Skillmaps>()
                .HasKey(c => new { c.employee_id, c.skillid });
            modelBuilder.Entity<Skillmaps>()
                .HasOne(a => a.employees)
                .WithMany(b => b.skillmaps)
                .HasForeignKey(c => c.employee_id);
            modelBuilder.Entity<Skillmaps>()
                .HasOne(a => a.skills)
                .WithMany(b => b.skillmaps)
                .HasForeignKey(c => c.skillid);
            #endregion

            #region Entity: User
            modelBuilder.Entity<User>()
                .ToTable("User");
            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .HasColumnType("NUMBER(5)")
                .ValueGeneratedNever();
            modelBuilder.Entity<User>()
                .Property(x=>x.UserName)
                .IsRequired().HasMaxLength(30)
                .HasColumnType("varchar");
            modelBuilder.Entity<User>()
                .Property(x=>x.Password)
                .IsRequired().HasMaxLength(30)
                .HasColumnType("varchar");
            modelBuilder.Entity<User>()
                .Property(x => x.Name)
                .HasMaxLength(30)
                .HasColumnType("varchar");
            modelBuilder.Entity<User>()
                .Property(x => x.Role)
                .HasMaxLength(30)
                .HasColumnType("varchar");
            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .HasColumnType("text");
            #endregion

            #region Entity: SoftLock
            //modelBuilder.Entity<SoftLock>()
            //    .Property(x => x.Id)
            //    .HasColumnType("NUMBER(5)")
            //    .ValueGeneratedNever()
            //    ;
            modelBuilder.Entity<SoftLock>()
                .ToTable("SoftLock");
            modelBuilder.Entity<SoftLock>()
                .Property(x => x.EmployeeId)
                .HasColumnType("NUMBER(5)")
                .ValueGeneratedNever();
            modelBuilder.Entity<SoftLock>()
                .Property(x => x.Manager).IsRequired()
                .HasMaxLength(30)
                .HasColumnType("varchar");
            modelBuilder.Entity<SoftLock>()
                .Property(x => x.Reqdate)
                .HasColumnType("date");
            modelBuilder.Entity<SoftLock>()
                .Property(x => x.Status)
                .HasMaxLength(30)
                .HasColumnType("varchar");
            modelBuilder.Entity<SoftLock>()
                .Property(x => x.Lastupdated)
                .HasColumnType("date");
            modelBuilder.Entity<SoftLock>()
                .Property(x => x.LockId)
                .HasColumnType("NUMBER(5)")
                .ValueGeneratedNever();
            modelBuilder.Entity<SoftLock>()
                .Property(x => x.Requestmessage)
                .HasColumnType("text");
            modelBuilder.Entity<SoftLock>()
                .Property(x => x.Wfmremark)
                .HasColumnType("text");
            modelBuilder.Entity<SoftLock>()
                .Property(x => x.Managerstatus)
                .HasMaxLength(30)
                .HasColumnType("varchar");
            modelBuilder.Entity<SoftLock>()
                .Property(x => x.Mgrstatuscomment)
                .HasColumnType("text");
            modelBuilder.Entity<SoftLock>()
                .Property(x => x.Mgrlastupdate)
                .HasColumnType("date");
            #endregion
        }
    }
}
