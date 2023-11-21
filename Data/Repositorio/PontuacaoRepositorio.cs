using GiceleBollmannAPI.Database.Contexto;
using GiceleBollmannAPI.Models;
using GiceleBollmannAPI.Models.Commands;

namespace GiceleBollmannAPI.Data.Repositorio
{
    public class PontuacaoRepositorio
    {
        public Pontuacao Votar(Pontuacao pontuacao)
        {
            using (var bancoDeDados = new GBcontexto())
            {
                bancoDeDados.PONTUACAO.Add(pontuacao);
                bancoDeDados.SaveChanges();
                return pontuacao;
            }
        }
        public Pontuacao MudarVoto(Pontuacao pontuacao)
        {

            using (var bancoDeDados = new GBcontexto())
            {
                bancoDeDados.PONTUACAO.Update(pontuacao);
                bancoDeDados.SaveChanges();
                return pontuacao;
            }
        }
       
    }
}
