using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTDV.Domain.DTO.JogadorDTO
{
    public class AdicionarJogadorDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public string Posicao { get; set; }
        [Required]
        public string Telefone { get; set; }
    }
}
