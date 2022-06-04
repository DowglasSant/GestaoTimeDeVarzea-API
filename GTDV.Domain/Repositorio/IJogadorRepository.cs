using GestaoDeTimes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTDV.Domain.Repositorio
{
    public interface IJogadorRepository
    {
        public Task<IEnumerable<Jogador>> ListarJogadores();
        public Task<Jogador> JogadorPorId(int id);
        public Task<IEnumerable<Jogador>> JogadorPorPosicao(string posicao);
        public Task AdicionarJogador(Jogador aluno);
        public Task AtualizarJogador(Jogador aluno);
        public Task RemoverJogador(int id);
    }
}
