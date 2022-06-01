namespace PetHouse.ContractsDto.Pet
{
    public class PetDto
    {
        public Guid PetId { get; set; }
        public string Nome { get; set; }
        public string NomeDoDOne { get; set; }
        public DateTime DataDeNascimento { get; set; }
    }
}
