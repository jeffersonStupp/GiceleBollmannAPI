using GiceleBollmannAPI.Database.Repositorio;
using GiceleBollmannAPI.Models;
using GiceleBollmannAPI.Models.Comands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GiceleBollmannAPI.Controllers
{
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public ProdutoRepositorio repositorio = new ProdutoRepositorio();

        [HttpGet]
        [Route("produto/listar")]
        public IActionResult ObterTodosProdutos()
        {
            try
            {
                var lista = repositorio.ObterTodosProdutos();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");

            }
        }

       
        

        [HttpGet]
        [Route("produto/obterportitulo/{titulo}")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            try
            {
                var produto = repositorio.ObterPorTitulo(titulo);
                if (produto == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(produto);
                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");

            }
        }

       
       
        [HttpGet]
        [Route("produto/obterporid/{id}")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var produto = repositorio.ObterPorId(id);
                if (produto == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(produto);
                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");

            }
        }

        [HttpDelete]
        [Route("produto/excluir/{id}")]
        
        public IActionResult Excluir(int id)
        {
            try
            {
                Produto produto = repositorio.ObterPorId(id);
                if (produto == null)
                {
                    return NotFound("Produto não encontrado");
                }

                repositorio.Exluir(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }


    }
}
