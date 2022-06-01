using PetHouse.ContractsDto.Consulta;

namespace PetHouse.Services.Abstractios
{
    public interface IConsultaVeterinariaService
    {
        Task<IEnumerable<ConsultaVeterinariaDto>> ObterTodosAsync(CancellationToken cancellationToken);
        Task<ConsultaVeterinariaDto> CadastrarAsync(NovaConsulta novaConsulta, CancellationToken cancellationToken);
        Task<ConsultaVeterinariaDto> AtualizarAsync(Guid consultaId, NovaConsulta novaConsulta, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid consultaId, CancellationToken cancellationToken);
    }
}
