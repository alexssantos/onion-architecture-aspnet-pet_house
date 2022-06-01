namespace PetHouse.ContractsDto.Consulta
{
    public class ConsultaVeterinariaDto
    {
        public string Descricao { get; set; }
        public string NomeAnimal { get; set; }
        public DateTime DataDaConsulta { get; set; }
        public string CpfDoDono { get; set; }
        public string NomeDoDono { get; set; }
    }
}
