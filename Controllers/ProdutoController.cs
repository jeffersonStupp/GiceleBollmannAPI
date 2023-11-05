using GiceleBollmannAPI.Database.Repositorio;
using GiceleBollmannAPI.Models;
using GiceleBollmannAPI.Models.Comands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GiceleBollmannAPI.Controllers
{
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        public ProdutoRepositorio repositorio = new ProdutoRepositorio();


        [AllowAnonymous]
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

        [HttpPut]
        [Route("produto/atualizar")]
        public IActionResult Atualizar([FromBody] Produto produto)
        {
            try
            {
                Produto produtoAtualizar = repositorio.ObterPorId(produto.Id);
                if (produtoAtualizar == null)
                {
                    return NotFound("Não foi possível encontrar o produto");
                }
                else
                {
                    produtoAtualizar.Id = produto.Id;
                    produtoAtualizar.Titulo = produto.Titulo;
                    produtoAtualizar.Descricao = produto.Descricao;
                    produtoAtualizar.Nota = produto.Nota;
                    produtoAtualizar.Imagem = produto.Imagem;
                    produtoAtualizar.Preco = produto.Preco;
                    repositorio.Atualizar(produtoAtualizar);
                    return Ok(produtoAtualizar);
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}"); ;
            }
        }
        [HttpPost]
        [Route("produto/cadastrar")]
        public IActionResult Cadastrar([FromBody]Produto produto)
        {
            try
            {
                if (produto == null)
                {
                    return BadRequest("Não foi possível obter o produto");
                }
                if (repositorio.ObterPorTitulo(produto.Titulo)!=null)
                {
                    return BadRequest("Já existe um produto com esse título");
                }
                repositorio.CadastrarProduto(produto);
                return Created($"", produto);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }

        }

       




    }
}
