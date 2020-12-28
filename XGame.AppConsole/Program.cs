using System;
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

            request.Email = "Paulo";
            request.Senha = "123456";
            service.AutenticarJogador(request);
            

            Console.ReadKey();

        }
    }
}
