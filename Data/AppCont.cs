using CadastroFornecedor.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroFornecedor.Data
{
    public class AppCont : DbContext
    {
        public AppCont(DbContextOptions<AppCont> options) : base(options)
        {

        }

        public DbSet <Cadastro> Cadastros{ get; set; }
    }
}
