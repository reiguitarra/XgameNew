using System;
using XGamer.Domain.Arguments.Jogador;
using XGamer.Domain.Entities;
using XGamer.Domain.Interfaces.Repositories;
using XGamer.Domain.Interfaces.Services;
using XGamer.Domain.Enums;
using XGamer.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using XGamer.Domain.Resources;
using prmToolkit.NotificationPattern.Extensions;

namespace XGamer.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
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

            if (request == null)
            {
                AddNotification("O AutenticarJogadorRequest é obrigatório!", Message.OBJECT_ERROR_01.ToFormat("AutenticarJogadorRequest"));

            }

            var email = new Email(request.Email);

            var jogador = new Jogador(email, request.Senha);

            AddNotifications(jogador, email);


            if (jogador.IsInvalid())
            {
                return null;
            }
            

            var response = _repositoryJogador.AutenticarJogador(jogador.Email.EndEmail, jogador.Senha);
            
            return response;
        }
    }
}
