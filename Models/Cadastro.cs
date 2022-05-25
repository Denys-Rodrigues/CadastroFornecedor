using System.ComponentModel.DataAnnotations;

namespace CadastroFornecedor.Models
{
    public class Cadastro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public string Contato { get; set; }
    }
}
