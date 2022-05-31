using PetHouse.Domain.Repositories;
using PetHouse.Services.Abstractios;

namespace PetHouse.Services.Pets
{
    public class PetService : IPetService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PetService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
    }
}
