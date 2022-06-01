namespace PetHouse.ContractsDto.Consulta
{
    public class NovaConsulta
    {
        public string Descricao { get; set; }
        public DateTime DataDaConsulta { get; set; }

        //ORM - Mapeamento de relacionamento
        public Guid PetId { get; set; }
        public Guid AgendadorId { get; set; }
    }
}
