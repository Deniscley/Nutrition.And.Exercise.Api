using Microsoft.EntityFrameworkCore;
using Nutrition.And.Exercise.Borders.DomainObjects;
using Nutrition.And.Exercise.Borders.Entities;
using Nutrition.And.Exercise.Borders.Interfaces.Data;
using Nutrition.And.Exercise.Borders.Mediator;
using Nutrition.And.Exercise.Borders.Messages;
using System.ComponentModel.DataAnnotations;

namespace Nutrition.And.Exercise.Data.Context
{
    public class DataContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DbSet<Client> Customers { get; set; }

        public DataContext(DbContextOptions options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            ApplyConfigurationContext.OnApplyConfiguration(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            var sucess = await base.SaveChangesAsync() > 0;
            if (sucess) await _mediatorHandler.PublishEvents(this);

            return sucess;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublishEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notifications)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearEvents());


            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
