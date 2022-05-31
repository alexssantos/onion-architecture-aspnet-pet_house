using PetHouse.ContractsDto.Consulta;
using PetHouse.Domain.Repositories;
using PetHouse.Services.Abstractios;

namespace PetHouse.Services.Consultas
{
    internal sealed class ConsultaVeterinariaService : IConsultaVeterinariaService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ConsultaVeterinariaService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<ConsultaVeterinariaDto>> ObterTodosAsync(CancellationToken cancellationToken)
        {
            var pets = await _repositoryManager.ConsultaVeterinariaRepository.GetAllAsync(cancellationToken);
            return pets.Select(cons => cons.ToDto());
        }
    }
}
