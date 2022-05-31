using PetHouse.ContractsDto.Pet;
using PetHouse.Domain.Commons;
using PetHouse.Domain.Consultas;

namespace PetHouse.Domain.Pets
{
    public class Pet : Entity
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string NomeDoDono { get; set; }

        public virtual ICollection<ConsultaVeterinaria> ListaDeConsultaVeterinaria { get; set; }

        public PetDto ToPetDto()
        {
            return new PetDto
            {
                Nome = Nome,
                DataDeNascimento = DataDeNascimento,
                NomeDoDOne = NomeDoDono,
            };
        }

    }
}
