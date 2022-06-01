using PetHouse.ContractsDto.Pet;
using PetHouse.Domain.Pets;
using PetHouse.Domain.Repositories;
using PetHouse.Services.Abstractios;

namespace PetHouse.Services.Pets
{
    internal sealed class PetService : IPetService
    {
        private readonly IRepositoryManager _repositoryManager;

        public PetService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<PetDto> Cadastrar(NovoPet novoPet, CancellationToken cancellationToken)
        {
            var criado = await _repositoryManager.PetRepositorio.InsertAsync(Pet.Criar(novoPet));
            return criado.ToPetDto();
        }

        public async Task<IEnumerable<PetDto>> ObterTodosAsync(CancellationToken cancellationToken)
        {
            var pets = await _repositoryManager.PetRepositorio.GetAllAsync(cancellationToken);
            return pets.Select(pet => pet.ToPetDto());
        }
    }
}
