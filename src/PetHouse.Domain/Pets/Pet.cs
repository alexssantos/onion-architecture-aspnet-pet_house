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

        public string CpfDoDono { get; set; }
        public string TipoDeAnimal { get; set; }

        public virtual ICollection<ConsultaVeterinaria> ListaDeConsultaVeterinaria { get; set; }

        public static Pet Criar(NovoPet pet)
        {
            return new Pet
            {
                CpfDoDono = pet.CpfDoDone,
                NomeDoDono = pet.NomeDoDone,
                DataDeNascimento = pet.DataDeNascimento,
                Nome = pet.Nome,
                TipoDeAnimal = pet.TipoDeAnimal,
            };
        }

        public PetDto ToPetDto()
        {
            return new PetDto
            {
                PetId = Id,
                Nome = Nome,
                DataDeNascimento = DataDeNascimento,
                NomeDoDOne = NomeDoDono,
            };
        }

    }
}
