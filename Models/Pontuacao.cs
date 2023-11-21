namespace GiceleBollmannAPI.Models
{
    public class Pontuacao
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public Usuario Usuario { get; set; }
        public Produto Produto { get; set; }
    }
}
