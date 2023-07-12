using ApiCentralPark.Database.Repositorio;
using ApiCentralPark.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ApiCentralPark.Controllers
{
    [ApiController]
    public class PessoaController : ControllerBase
    {
        public PessoaRepositorio Repositorio = new PessoaRepositorio();

        [HttpGet]
        [Route("pessoa/obterporid/{id}")]
        [ProducesResponseType(typeof(Pessoa), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var pessoa = Repositorio.ObterPorId(id);
                if (pessoa == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(pessoa);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpGet]
        [Route("pessoa/obter")]
        [ProducesResponseType(typeof(List<Pessoa>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult ObterTodos()
        {
            try
            {
                var lista = Repositorio.ObterTodos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpPost]
        [Route("pessoa/adicionar")]
        [ProducesResponseType(typeof(Pessoa), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Adicionar([FromBody] Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                {
                    return BadRequest("Nao encontrado");
                }
                Repositorio.Add(pessoa);
                return Created("", pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpPut]
        [Route("pessoa/atualizar")]
        [ProducesResponseType(typeof(Pessoa), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Atualizar([FromBody] Pessoa pessoa)
        {
            try
            {
                Pessoa pessoaAtualizar = Repositorio.ObterPorId(pessoa.Id);

                if (pessoaAtualizar == null)
                {
                    return NotFound("Não foi possível encontrar a pessoa");
                }
                else
                {
                    pessoaAtualizar.Nome = pessoa.Nome;
                    pessoaAtualizar.DataNascimento= pessoa.DataNascimento;
                    pessoaAtualizar.Cpf = pessoa.Cpf;
                    pessoaAtualizar.Rg = pessoa.Rg;
                    pessoaAtualizar.Email = pessoa.Email;
                    pessoaAtualizar.Telefone = pessoa.Telefone;
                    pessoaAtualizar.Rua = pessoa.Rua;
                    pessoaAtualizar.Numero= pessoa.Numero;
                    pessoaAtualizar.Bairro= pessoa.Bairro;
                    pessoaAtualizar.Cidade= pessoa.Cidade;
                    pessoaAtualizar.Estado= pessoa.Estado;

                    Repositorio.Edit(pessoa);
                    return Ok(pessoa);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpDelete]
        [Route("pessoa/excluir/{id}")]
        [ProducesResponseType(typeof(Nullable), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public IActionResult Excluir(int id)
        {
            try
            {
                Pessoa pessoa = Repositorio.ObterPorId(id);
                if (pessoa == null)
                {
                    return NotFound("Pessoa não encontrada");
                }

                Repositorio.Del(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpGet]
        [Route("pessoa/buscacep/{cep}")]
        public async Task<IActionResult> BuscaCep(string cep)
        {
            try
            {
                using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) })
                {
                    using (var message = new HttpRequestMessage())
                    {
                        message.RequestUri = new Uri($"https://viacep.com.br/ws/{cep}/json");
                        message.Method = new HttpMethod("get");

                        var response = await httpClient.SendAsync(message);

                        if (!response.IsSuccessStatusCode)
                        {
                            return NotFound("Não foi possível encontrar os dados com o CEP informado");
                        }

                        var jsonRetorno = await response.Content.ReadAsStringAsync();

                        var objetoViaCep = JsonConvert.DeserializeObject<ViaCep>(jsonRetorno);

                        return Ok(objetoViaCep);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
    }
}