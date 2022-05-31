using PetHouse.Domain.Pets;
using PetHouse.Domain.Repositories;
using PetHouse.Persistence.Database;
using PetHouse.Persistence.Repositories.Base;

namespace PetHouse.Persistence.Repositories
{
    internal sealed class PetRepository : RepositoryBase<Pet>, IPetRepository
    {
        public PetRepository(PetHouseContext context) : base(context)
        {
        }
    }
}
