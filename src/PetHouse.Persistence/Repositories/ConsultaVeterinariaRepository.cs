using PetHouse.Domain.Consultas;
using PetHouse.Domain.Repositories;
using PetHouse.Persistence.Database;
using PetHouse.Persistence.Repositories.Base;

namespace PetHouse.Persistence.Repositories
{
    internal sealed class ConsultaVeterinariaRepository : RepositoryBase<ConsultaVeterinaria>, IConsultaVeterinariaRepository
    {
        public ConsultaVeterinariaRepository(PetHouseContext context) : base(context)
        {
        }
    }
}
