using CadastroFornecedor.Models;

namespace CadastroFornecedor.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppCont>();
                context.Database.EnsureCreated();

                //Criar Fornecedores
                if (!context.Cadastros.Any())
                {
                    context.Cadastros.AddRange(new List<Cadastro>()
                    {
                        new Cadastro()
                        {
                            RazaoSocial = "Milhouse Tecnologia",
                            NomeFantasia = "Milhouse",
                            Email = "milhouse@teste.com.br",
                            Telefone = "55 99876394",
                            Endereco = "Rua Francisco Nº 123",
                            Contato = "Alfredo"
                        },
                        new Cadastro()
                        {
                            RazaoSocial = "Barte Tecnologia",
                            NomeFantasia = "Barte",
                            Email = "Barte@teste.com.br",
                            Telefone = "55 99875194",
                            Endereco = "Rua Antonio Nº 321",
                            Contato = "Cleiton"
                        },
                        new Cadastro()
                        {
                            RazaoSocial = "Nick Tecnologia",
                            NomeFantasia = "NickHouse",
                            Email = "nickhouse@teste.com.br",
                            Telefone = "55 99831242",
                            Endereco = "Rua José Nº4 465",
                            Contato = "Judite"
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
