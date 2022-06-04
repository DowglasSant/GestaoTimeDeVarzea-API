using GestaoDeTimes.Context;
using GestaoDeTimes.Entidades;
using GTDV.Domain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTDV.Infra.Repositorio
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly GestaoTimesContexto jogadorContext;

        public JogadorRepository(GestaoTimesContexto jogadorContext)
        {
            this.jogadorContext = jogadorContext;
        }

        public async Task<IEnumerable<Jogador>> ListarJogadores()
        {
            return await jogadorContext.Jogador.ToListAsync();
        }

        public async Task<Jogador> JogadorPorId(int id)
        {
            return await jogadorContext.Jogador.FindAsync(id);
        }

        public async Task AdicionarJogador(Jogador jogador)
        {
            jogadorContext.Jogador.Add(jogador);
            await jogadorContext.SaveChangesAsync();
        }

        public async Task AtualizarJogador(Jogador jogador)
        {
            var existingJogador = await jogadorContext.Jogador.FindAsync(jogador.Id);

            if (existingJogador is null)
                throw new NullReferenceException();

            jogadorContext.Entry(existingJogador).CurrentValues.SetValues(jogador);

            await jogadorContext.SaveChangesAsync();
        }

        public async Task RemoverJogador(int id)
        {
            var jogadorRemover = await jogadorContext.Jogador.FindAsync(id);

            if (jogadorRemover == null)
                throw new NullReferenceException();

            jogadorContext.Jogador.Remove(jogadorRemover);
            await jogadorContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Jogador>> JogadorPorPosicao(string posicao)
        {
            return await jogadorContext.Jogador.Where(b => b.Posicao == posicao).ToListAsync();
        }
    }
}
