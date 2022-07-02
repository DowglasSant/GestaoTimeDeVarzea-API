using GestaoDeTimes.Entidades;
using GTDV.Application.Interfaces;
using GTDV.Domain.DTO.JogadorDTO;
using GTDV.Domain.Pagination;
using GTDV.Domain.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeTimes.Controladores
{   
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("jogador")]
    [ApiController]
    public class ControladorJogadores : ControllerBase
    {
        private readonly IJogadorService jogadorService;

        public ControladorJogadores(IJogadorService jogadorService)
        {
            this.jogadorService = jogadorService;
        }

        [HttpGet]
        public async Task<IEnumerable<Jogador>> ListarJogadores([FromQuery] JogadorParameters jogadorParameters)
        {
            var jogadores = await jogadorService.ListarJogadores(jogadorParameters);
            return jogadores;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jogador>> JogadorPorId(int id)
        {
            var jogadorExistente = await jogadorService.JogadorPorId(id);

            if (jogadorExistente is null)
            {
                return NotFound();
            }

            return Ok(jogadorExistente);
        }
        
        [HttpPost]
        public async Task<ActionResult> CriarJogador(AdicionarJogadorDTO jogador)
        {
            Jogador novoJogador = new()
            {
                Nome = jogador.Nome,
                Idade = jogador.Idade,
                Posicao = jogador.Posicao,
                Telefone = jogador.Telefone,
                DataDeAdicao = DateTimeOffset.UtcNow
            };

            return Ok(await jogadorService.AdicionarJogador(novoJogador));
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarJogador(int id, AdicionarJogadorDTO atualizaJogador)
        {
            var jogadorExistente = await jogadorService.JogadorPorId(id);

            if (jogadorExistente is null)
                return NotFound();

            Jogador jogadorAtt = jogadorExistente with
            {
                Nome = atualizaJogador.Nome,
                Idade = atualizaJogador.Idade,
                Posicao = atualizaJogador.Posicao,
                Telefone = atualizaJogador.Telefone
            };

            return Ok(await jogadorService.AtualizarJogador(jogadorAtt));
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var jogadorExistente = jogadorService.JogadorPorId(id);

            if (jogadorExistente is null)
            {
                return NotFound();
            }

            await jogadorService.RemoverJogador(id);

            return Ok();
        }

        [HttpGet("busca/{posicao}")]
        public async Task<ActionResult<Jogador>> JogadorPorPosicao(string posicao)
        {
            var jogadorExistente = await jogadorService.JogadorPorPosicao(posicao);

            if (jogadorExistente is null)
            {
                return NotFound();
            }

            return Ok(jogadorExistente);
        }
    }
}
