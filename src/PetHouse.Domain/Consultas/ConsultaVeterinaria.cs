using PetHouse.ContractsDto.Consulta;
using PetHouse.Domain.Commons;
using PetHouse.Domain.Pets;
using PetHouse.Domain.Usuarios;

namespace PetHouse.Domain.Consultas
{
    public class ConsultaVeterinaria : Entity
    {
        public string Descricao { get; set; }
        public DateTime DataDaConsulta { get; set; }

        //ORM - Mapeamento de relacionamento
        public Guid PetId { get; set; }
        public virtual Pet Pet { get; set; }
        public Guid AgendadorId { get; set; }
        public virtual Usuario Agendador { get; set; }

        public ConsultaVeterinariaDto ToDto()
        {
            return new ConsultaVeterinariaDto()
            {
                DataDaConsulta = DataDaConsulta,
                Descricao = Descricao,
                NomeAnimal = Pet.Nome
            };
        }
    }
}
