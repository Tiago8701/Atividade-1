namespace Atividade_1.Models
{
    public class Convidado
    {
        public int ConvidadoId { get; set; }
        public string Nome { get; set; }
        public string EMail { get; set; }
        public string Telefone { get; set; }
        public bool? Comparecimento { get; set; }
    }
}
