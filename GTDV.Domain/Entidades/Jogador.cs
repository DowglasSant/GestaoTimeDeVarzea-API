using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoDeTimes.Entidades
{   
    public record Jogador
    {
        [Key]
        [Column]
        public int Id { get; set; }
        [Column]
        public string Nome { get; set; }
        [Column]
        public int Idade { get; set; }
        [Column]
        public string Posicao { get; set; }
        [Column]
        public string Telefone { get; set; }
        [Column]
        public DateTimeOffset DataDeAdicao { get; set; }
    }
}
