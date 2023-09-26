using GiceleBollmannAPI.Database.Contexto;
using GiceleBollmannAPI.Database.Repositorio.Helpers;
using GiceleBollmannAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GiceleBollmannAPI.Database.Repositorio
{
    public class ProdutoRepositorio
    {
        public Produto CadastrarProduto( Produto produto)
        {
            using (var banco = new GBcontexto())
            {
                
                produto.Titulo = Helper.TitleCase(produto.Titulo);
                
                banco.PRODUTOS.Add(produto);
                banco.SaveChanges();
                return produto;
            }
        }
        

        public List<Produto> ObterTodosProdutos()
        {
            using (var banco = new GBcontexto())
            {

                var listaprotutos = banco.PRODUTOS.ToList();

                return listaprotutos;
            }

        }
        public List<Produto> ListarTops()
        {
            using (var banco = new GBcontexto())
            {
                var listaprotutos = banco.PRODUTOS.OrderByDescending(p => p.nota).Take(6).ToList();
                return listaprotutos;
            }
           
        }
        public Produto ObterPorTitulo(string titulo)
        {
            using (var banco = new GBcontexto())
            {
                var produto = banco.PRODUTOS.Where(x => x.Titulo.ToUpper() == titulo.ToUpper()).FirstOrDefault();

                return produto;
            }

        }
        
       
        public Produto ObterPorId(int id)
        {
            using (var banco = new GBcontexto())
            {
                var produto = banco.PRODUTOS.Where(x => x.Id == id).FirstOrDefault();

                return produto;
            }

        }
       
        public void Exluir(int id)
        {
            using (var banco = new GBcontexto())
            {
                var produto = banco.PRODUTOS.Where(x => x.Id == id).FirstOrDefault();
                if (produto != null)
                {
                    banco.Remove(produto);
                    banco.SaveChanges();
                }
            }
        }

    }
}
