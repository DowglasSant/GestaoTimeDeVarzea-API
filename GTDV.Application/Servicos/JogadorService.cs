using AutoMapper;
using GestaoDeTimes.Entidades;
using GTDV.Application.Interfaces;
using GTDV.Domain.Pagination;
using GTDV.Domain.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTDV.Application.Servicos
{
    public class JogadorService : IJogadorService
    {
        private readonly IJogadorRepository repository;

        public JogadorService(IJogadorRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Jogador>> ListarJogadores(JogadorParameters jogadorParameters) 
        {
            var jogadores = await repository.ListarJogadores(jogadorParameters);

            return jogadores;
        }

        public async Task<Jogador> JogadorPorId(int id) 
        {
            var jogador = await repository.JogadorPorId(id);

            if (jogador is null)
                return null;

            return jogador;
        }

        public async Task<Jogador> AdicionarJogador(Jogador jogador) 
        {
            var formataPosicao = jogador.Posicao;

            formataPosicao = formataPosicao.ToLower();

            if (formataPosicao.Contains(" "))
               formataPosicao = formataPosicao.Replace(" ", "-");

            jogador.Posicao = formataPosicao;

            await repository.AdicionarJogador(jogador);

            return jogador;
        }

        public async Task<Jogador> AtualizarJogador(Jogador jogador) 
        {
            await repository.AtualizarJogador(jogador);

            return jogador;
        }

        public async Task RemoverJogador(int id) 
        {
            await repository.RemoverJogador(id);
        }

        public async Task<IEnumerable<Jogador>> JogadorPorPosicao(string posicao)
        {
            var jogador = await repository.JogadorPorPosicao(posicao);

            if (jogador is null)
                return null;

            return jogador;
        }
    }
}
