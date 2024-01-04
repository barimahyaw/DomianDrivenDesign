namespace Domain.Primitives;

public abstract class Entity
{
    private readonly List<DomainEvent> _domainEvents = [];

    public ICollection<DomainEvent> DomainEvents => _domainEvents;

    // protected method that are only callable by the entities
    protected void Raise(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}