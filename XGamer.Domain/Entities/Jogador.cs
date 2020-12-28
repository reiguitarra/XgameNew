using System;
using XGamer.Domain.Enums;
using XGamer.Domain.ValueObjects;
using prmToolkit.NotificationPattern;


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

            new AddNotifications<Jogador>(this).IfNotEmail(x => x.Email.EndEmail, "Informe um E-mail válido! ")
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "A senha deve contem entre 6 e 32 caractéres! "); 

            //if (request == null)
            //{
            //    throw new Exception("O AutenticarJogadorRequest é obrigatório!");

            //}

          

            //if (request.Senha.Length < 6)
            //{
            //    throw new Exception("A senha deve conter no mínimo 6 caracteresS");
            //}


        }
    }
}
