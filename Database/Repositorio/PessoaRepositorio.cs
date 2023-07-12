using ApiCentralPark.Database.Contexto;
using ApiCentralPark.Database.Repositorio.Helpers;
using ApiCentralPark.Models;

namespace ApiCentralPark.Database.Repositorio
{
    public class PessoaRepositorio
    {
        public Pessoa Add(Pessoa pessoa)
        {
            using (var banco = new CentalParkContext())
            {
                pessoa.Nome = Helper.RemoverCaracteres(pessoa.Nome);
                pessoa.Nome = Helper.TitleCase(pessoa.Nome);
                banco.PessoasDatabase.Add(pessoa);
                banco.SaveChanges();
            }
            return pessoa;
        }

        public Pessoa Edit(Pessoa pessoa)
        {
            using (var banco = new CentalParkContext())
            {
                pessoa.Nome = Helper.RemoverCaracteres(pessoa.Nome);
                pessoa.Nome = Helper.TitleCase(pessoa.Nome);
                banco.PessoasDatabase.Update(pessoa);
                banco.SaveChanges();
            }
            return pessoa;
        }

        public void Del(int id)
        {
            using (var banco = new CentalParkContext())
            {
                var pessoa = banco.PessoasDatabase.Where(pessoa => pessoa.Id == id).FirstOrDefault();
                if (pessoa != null)
                {
                    banco.Remove(pessoa);
                    banco.SaveChanges();
                }
            }
        }

        public List<Pessoa> ObterTodos()
        {
            using (var banco = new CentalParkContext())
            {
                {
                    var listaPessoas = banco.PessoasDatabase.ToList();
                    return listaPessoas;
                }
            }
        }

        public Pessoa ObterPorId(int id)
        {
            using (var banco = new CentalParkContext())
            {
                var pessoa = banco.PessoasDatabase
                    .Where(pessoa => pessoa.Id == id)
                    .FirstOrDefault();

                return pessoa;
            }
        }
    }
}