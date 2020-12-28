using XGamer.Domain.Arguments.Jogador;
using System;
using XGamer.Domain.Entities;

namespace XGamer.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);

       Guid AdicionarJogador(Jogador jogador);
    }
}
    