using PetHouse.ContractsDto.Pet;

namespace PetHouse.Services.Abstractios
{
    public interface IPetService
    {
        Task<IEnumerable<PetDto>> ObterTodosAsync(CancellationToken cancellationToken);
        Task<PetDto> CadastrarAsync(NovoPet novoPet, CancellationToken cancellationToken);
        Task<PetDto> AtualizarAsync(Guid petId, NovoPet novoPet, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid petId, CancellationToken cancellationToken);
    }
}
