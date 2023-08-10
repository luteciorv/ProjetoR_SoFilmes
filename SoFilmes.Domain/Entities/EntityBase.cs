namespace SoFilmes.Domain.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedAt = UpdatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; protected set; }
    }
}
