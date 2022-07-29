using System.Text.Json.Serialization;

namespace MartelinhoDeOuro.API.Models
{
    public class Proprietario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        [JsonIgnore]
        public List<Veiculo> Veiculos { get; set; }
        public Endereco Endereco { get; set; }
    }
}
