using DAL.Models;
using DAL.Models.Helping;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public partial class AppDbContext:DbContext
    {

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }


        #region MODELLER
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<ChatModel> Chats { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<HelpingModel> Helps { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UniversityModel> Universities { get; set; }
        public DbSet<HelpTypeModel> HelpTypes { get; set; }
        #endregion

        #region Connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#if DEBUG
                
                optionsBuilder.UseSqlServer("Server=207.180.235.216,1435;Initial Catalog=legupDB; connection timeout=160; User Id=legupSA;Password=Axe84_35x;");
#else
                
				  optionsBuilder.UseSqlServer("Server=207.180.235.216,1435;Initial Catalog=legupDB; connection timeout=160; User Id=legupSA;Password=Axe84_35x;");
#endif
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            //modelBuilder.HasDefaultSchema("BrusaMES");


            base.OnModelCreating(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #endregion
    }
}
