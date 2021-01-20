using System;
using XGamer.Domain.Enums;
using XGamer.Domain.ValueObjects;
using prmToolkit.NotificationPattern;
using XGamer.Domain.Resources;

namespace XGamer.Domain.Entities
{
    public class Jogador : Notifiable

    {
        
        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public string Senha { get; set; }
        public EnumSituacaoJogador Status { get; set; }

        public Jogador()
        {

        }

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this)
                
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, Message.PASSWORD_ERROR_01); 

            //if (request.Senha.Length < 6)
            //{
            //    throw new Exception("A senha deve conter no mínimo 6 caracteresS");
            //}


        }
    }
}
