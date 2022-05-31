using PetHouse.ContractsDto.Pet;

namespace PetHouse.Services.Abstractios
{
    public interface IPetService
    {
        Task<IEnumerable<PetDto>> ObterTodosAsync(CancellationToken cancellationToken);
    }
}
