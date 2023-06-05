using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nutrition.And.Exercise.Borders.DomainObjects;
using Nutrition.And.Exercise.Borders.Entities;
using Nutrition.And.Exercise.Borders.Interfaces.Data;
using Nutrition.And.Exercise.Borders.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.And.Exercise.Data.Context
{
    public class DataContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        IConfiguration Configuration { get; }
        public string ConnectionString { get; set; }
        public DbSet<Client> Customers { get; set; }

        public DataContext()
        {
            //ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB_NutritionAndExercise;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            ConnectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public DataContext(DbContextOptions options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
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
