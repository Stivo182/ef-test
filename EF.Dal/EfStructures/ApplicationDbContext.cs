
using EF.Models.Entities;
using EF.Dal.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EF.Dal.EfStructures;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        base.SavingChanges += (sender, args) =>
        {
            Console.WriteLine($"Saving changes for {((ApplicationDbContext)sender)!.Database!.GetConnectionString()}");
        };
        base.SavedChanges += (sender, args) =>
        {
            Console.WriteLine($"Saved {args!.EntitiesSavedCount} changes for" +
                $" {((ApplicationDbContext)sender)!.Database!.GetConnectionString()}");
        };
        base.SaveChangesFailed += (sender, args) =>
        {
            Console.WriteLine($"An exception occured! {args.Exception.Message}");
        };

        ChangeTracker.Tracked += ChangeTracker_Tracked;
        ChangeTracker.StateChanged += ChangeTracker_StateChanged;
    }

    public DbSet<Campaign> Campaigns { get; set; }

    public DbSet<CampaignScene> CampaignScenes { get; set; }

    public DbSet<SceneObject> SceneObjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Campaign>(entity =>
        {
            entity.HasMany(e => e.CampaignScenes)
                .WithOne(c => c.Campaign)
                .HasForeignKey(e => e.CampaignId);
        });

        modelBuilder.Entity<CampaignScene>(entity =>
        {
            entity.HasIndex(e => e.CampaignId, "IX_CampaignScenes_CampaignId");

            entity.HasOne(d => d.Campaign)
                .WithMany(p => p.CampaignScenes)
                .HasForeignKey(d => d.CampaignId);

            entity.HasMany<SceneObject>(e => e.SceneObjects)
                .WithOne(c => c.CampaignScene!)
                .HasForeignKey(e => e.CampaignSceneId);
        });

        modelBuilder.Entity<SceneObject>(entity =>
        {
            entity.HasIndex(e => e.CampaignSceneId, "IX_SceneObjects_CampaignSceneId");

            entity.HasOne(d => d.CampaignScene)
                .WithMany(p => p.SceneObjects)
                .HasForeignKey(d => d.CampaignSceneId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override int SaveChanges()
    {
        try
        {
            return base.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex) 
        {
            throw new CustomConcurrencyException("A concurrency error happend", ex);
        }
        catch (RetryLimitExceededException ex)
        {
            throw new CustomRetryLimitExceededException("There is a problem with SQL Server", ex);
        }
        catch (DbUpdateException ex)
        {
            throw new CustomDbUpdateException("An error occured updating the database", ex);
        }
        catch (Exception ex)
        {
            throw new CustomException("An error occured updating the database", ex);
        }
    }

    private void ChangeTracker_Tracked(object? sender, EntityTrackedEventArgs e)
    {
        string source = (e.FromQuery) ? "Database" : "Code";
        if(e.Entry.Entity is Campaign c)
        {
            Console.WriteLine($"Campaign entry {c.Name} was added from {source}");
        }
    }

    private void ChangeTracker_StateChanged(object? sender, EntityStateChangedEventArgs e)
    {
        if(e.Entry.Entity is not Campaign c)
        {
            return;
        }

        var action = string.Empty;
        Console.WriteLine($"Campaign {c.Name} was {e.OldState} before the state changed to {e.NewState}");
        switch (e.NewState)
        {
            case EntityState.Unchanged:
                action = e.OldState switch
                {
                    EntityState.Added => "Added",
                    EntityState.Modified => "Edited",
                    _ => action
                };
                Console.WriteLine($"The object was {action}");
                break;
        }
    }
}
