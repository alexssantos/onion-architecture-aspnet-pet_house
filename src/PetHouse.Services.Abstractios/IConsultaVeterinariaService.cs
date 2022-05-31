using PetHouse.ContractsDto.Consulta;

namespace PetHouse.Services.Abstractios
{
    public interface IConsultaVeterinariaService
    {
        Task<IEnumerable<ConsultaVeterinariaDto>> ObterTodosAsync(CancellationToken cancellationToken);
    }
}
