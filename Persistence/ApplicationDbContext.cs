using Domain.Customers;
using Domain.Orders;
using Domain.Primitives;
using Domain.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext(DbContextOptions options, IPublisher publisher) 
    : DbContext(options)
{
    private readonly IPublisher _publisher = publisher;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }    
    public DbSet<Product> Products { get; set; }
    public DbSet<LineItem> LineItems { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker.Entries<Entity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Count != 0)
            .SelectMany(e => e.DomainEvents);

        var result = await base.SaveChangesAsync(cancellationToken);

        // this isn't a 100% solution but rather using the outbox pattern
        // where you persist the domain event into a data base and use background job to publish them
        foreach(var domainEvent in domainEvents) 
            await _publisher.Publish(domainEvent, cancellationToken);

        return result;
    }

    private async Task PublishDomainEventsAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker.Entries<Entity>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Count != 0)
            .SelectMany(e =>
            {
                var domainEvents = e.DomainEvents;
                e.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach(var domainEvent in domainEvents) 
            await _publisher.Publish(domainEvent, cancellationToken);
    }
}
