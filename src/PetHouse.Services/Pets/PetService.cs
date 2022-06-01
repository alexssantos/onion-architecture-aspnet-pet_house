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

        public async Task<PetDto> AtualizarAsync(Guid petId, NovoPet novoPet, CancellationToken cancellationToken)
        {
            //buscar para ver se existe.
            var pet = await _repositoryManager.PetRepositorio.GetbyIdAsync(petId, cancellationToken);
            if (pet == null)
            {
                throw new Exception("Pet não encontrado.");
            }

            var atualizado = pet.AtualizarPor(novoPet);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return atualizado.ToPetDto();
        }

        public async Task<PetDto> CadastrarAsync(NovoPet novoPet, CancellationToken cancellationToken)
        {
            var criado = await _repositoryManager.PetRepositorio.InsertAsync(Pet.Criar(novoPet), cancellationToken);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return criado.ToPetDto();
        }

        public async Task ExcluirAsync(Guid petId, CancellationToken cancellationToken)
        {
            _repositoryManager.PetRepositorio.Delete(petId);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<PetDto>> ObterTodosAsync(CancellationToken cancellationToken)
        {
            var pets = await _repositoryManager.PetRepositorio.GetAllAsync(cancellationToken);
            return pets.Select(pet => pet.ToPetDto());
        }
    }
}
