using PetHouse.ContractsDto.Consulta;
using PetHouse.Domain.Consultas;
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

        public async Task<ConsultaVeterinariaDto> AtualizarAsync(Guid consultaId, NovaConsulta novaConsulta, CancellationToken cancellationToken)
        {
            var usuario = await _repositoryManager.UsuarioRepositorio.GetbyIdAsync(novaConsulta.AgendadorId, cancellationToken);
            if (usuario == null) throw new Exception("usuario não encontrada.");

            var pet = await _repositoryManager.PetRepositorio.GetbyIdAsync(novaConsulta.PetId, cancellationToken);
            if (pet == null) throw new Exception("pet não encontrado.");

            var consulta = await _repositoryManager.ConsultaVeterinariaRepository.GetbyIdAsync(consultaId, cancellationToken);

            //buscar para ver se existe.
            if (consulta == null)
                throw new Exception("Consulta não encontrado.");


            var atualizado = consulta.AtualizarPor(novaConsulta);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return atualizado.ToDto();
        }

        public async Task<ConsultaVeterinariaDto> CadastrarAsync(NovaConsulta novaConsulta, CancellationToken cancellationToken)
        {
            var criado = await _repositoryManager.ConsultaVeterinariaRepository.InsertAsync(ConsultaVeterinaria.Criar(novaConsulta), cancellationToken);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
            return criado.ToDto();
        }

        public async Task ExcluirAsync(Guid consultaId, CancellationToken cancellationToken)
        {
            _repositoryManager.ConsultaVeterinariaRepository.Delete(consultaId);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ConsultaVeterinariaDto>> ObterTodosAsync(CancellationToken cancellationToken)
        {
            var pets = await _repositoryManager.ConsultaVeterinariaRepository.GetAllAsync(cancellationToken);
            return pets.Select(cons => cons.ToDto());
        }
    }
}
