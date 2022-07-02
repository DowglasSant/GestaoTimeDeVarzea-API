using GestaoDeTimes.Entidades;
using GTDV.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTDV.Application.Interfaces
{
    public interface IJogadorService
    {
        public Task<IEnumerable<Jogador>> ListarJogadores(JogadorParameters jogadorParameters);
        public Task<Jogador> JogadorPorId(int id);
        public Task<IEnumerable<Jogador>> JogadorPorPosicao(string posicao);
        public Task<Jogador> AdicionarJogador(Jogador jogador);
        public Task<Jogador> AtualizarJogador(Jogador jogador);
        public Task RemoverJogador(int id);
    }
}
