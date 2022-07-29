using System.Text.Json.Serialization;

namespace MartelinhoDeOuro.API.Models
{
    public class Veiculo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public Guid ProprietarioId { get; set; }
        [JsonIgnore]
        public Proprietario Proprietario { get; set; }
    }
}
