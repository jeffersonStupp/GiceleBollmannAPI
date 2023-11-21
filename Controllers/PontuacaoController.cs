using GiceleBollmannAPI.Data.Repositorio;
using GiceleBollmannAPI.Database.Repositorio;
using GiceleBollmannAPI.Models;
using GiceleBollmannAPI.Models.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiceleBollmannAPI.Controllers
{

    [ApiController]
    public class PontuacaoController : ControllerBase
    {
        public PontuacaoRepositorio pontuacaoRepositorio = new PontuacaoRepositorio();
        public ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
        public UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

        [HttpPost]
        [Route("pontuacao/votar")]
        public IActionResult Votar(Pontuacao pontuacao)
        {
            try
            {
                var usuario = usuarioRepositorio.ObterPorId(pontuacao.Usuario.Id);
                var produto = produtoRepositorio.ObterPorId(pontuacao.Produto.Id);
                if (usuario == null)
                {
                    return BadRequest("Produto não encontrado");
                }
                if (produto == null)
                {
                    return BadRequest("Usuario não encontrado");
                }
                if (pontuacao.Nota < 0 && pontuacao.Nota > 5)
                {
                    return BadRequest("Nota inválida");
                }
                var Nota = pontuacaoRepositorio.Votar(pontuacao);





                return Ok(Nota);



            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }



    }
}
