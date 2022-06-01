namespace PetHouse.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IUnitOfWork UnitOfWork { get; }
        IUsuarioRepositorio UsuarioRepositorio { get; }
        IPetRepository PetRepositorio { get; }
        IConsultaVeterinariaRepository ConsultaVeterinariaRepository { get; }
    }
}
