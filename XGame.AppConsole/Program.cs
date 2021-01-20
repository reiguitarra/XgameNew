using System;
using System.Linq;
using XGamer.Domain.Arguments.Jogador;
using XGamer.Domain.Services;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Iniciando sistema.......");

            var service = new ServiceJogador();
            Console.WriteLine("Criei a Instância do serviço....");


            AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            Console.WriteLine("Criei uma instância do meu objeto request....");

            request.Email = "Paulo@modernizar.com.br";
            request.Senha = "123456789";
            

          
            var response = service.AutenticarJogador(request);

            Console.WriteLine("Serviço válido : "   + service.IsInvalid());

            service.Notifications.ToList().ForEach(x =>
            {

                Console.WriteLine(x.Message);
            });

            Console.ReadKey();

        }
    }
}
