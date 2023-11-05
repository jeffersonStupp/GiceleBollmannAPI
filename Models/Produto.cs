namespace GiceleBollmannAPI.Models
{
    public class Produto

    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int? Nota { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
    }
}
