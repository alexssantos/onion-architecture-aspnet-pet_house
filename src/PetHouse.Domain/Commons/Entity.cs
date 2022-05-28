namespace PetHouse.Domain.Commons
{
    public class Entity
    {
        public Entity(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public DateTime DataCriacao
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        protected internal DateTime? dateCreated = null;

        public DateTime? DataUltimaAtualizacao { get; set; }
    }
}
