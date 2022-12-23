using LibTech.SharedKernel.Interfaces;

namespace LibTech.SharedKernel
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        //public int Version { get; set; }
        //public List<DomainEvent> _events = new List<DomainEvent>();
    }
}
