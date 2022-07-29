namespace MartelinhoDeOuro.API.Models
{
    public class Servico
    {
        public Guid Id { get; set; }
        public float Valor { get; set; }
        public Guid VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public Guid ProprietarioId { get; set; }
        public Proprietario Proprietario { get; set; }
        public string Descricao { get; set; }
    }
}
