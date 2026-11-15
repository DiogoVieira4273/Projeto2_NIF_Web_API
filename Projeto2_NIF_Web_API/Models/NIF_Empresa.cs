namespace Projeto2_NIF_Web_API.Models
{
    public class NIF_Empresa
    {
        public int ID { get; set; }
        public int NIF { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PC4 { get; set; }
        public int PC3 { get; set; }
        public string Region { get; set; }
        public string County { get; set; }
        public string Parish { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Website { get; set; }
        public int Fax { get; set; }
        public string Imagem_URL { get; set; }
    }
}
