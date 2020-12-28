using System;
using XGamer.Domain.Arguments.Jogador;
using XGamer.Domain.Entities;
using XGamer.Domain.Interfaces.Repositories;
using XGamer.Domain.Interfaces.Services;
using XGamer.Domain.Enums;
namespace XGamer.Domain.Services
{
    public class ServiceJogador : IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {

        }
        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {

            Jogador jogador = new Jogador();

            jogador.Email = request.Email;
            jogador.Nome = request.Nome;
            jogador.Status = EnumSituacaoJogador.EmAndamento;
            
            Guid id = _repositoryJogador.AdicionarJogador(jogador);

            return new AdicionarJogadorResponse() { Id = id, Message = "Operação realizada com Sucesso! " };
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
         
            var response = _repositoryJogador.AutenticarJogador(request);
            
            return response;
        }
    }
}
