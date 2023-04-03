using Microsoft.EntityFrameworkCore;
using ef_test.Models;

namespace ef_test
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

            SavingChanges += (sender, args) =>
            {
                Console.WriteLine($"Savings changes for {((DbContext)sender).Database.GetConnectionString()}");
            };
            SavedChanges += (sender, args) =>
            {
                Console.WriteLine($"Saved {args.EntitiesSavedCount} entities");
            };
            SaveChangesFailed += (sender, args) =>
            {
                Console.WriteLine($"An expection occurred! {args.Exception.Message} entities");
            };
        }

        public DbSet<Models.Campaign> Campaigns { get; set; }
        public DbSet<Models.CampaignScene> CampaignScenes { get; set; }
        public DbSet<Models.SceneObject> SceneObjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<CampaignModel>().HasNoKey();
           // modelBuilder.Entity<CampaignSceneModel>().HasNoKey();
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }

}
