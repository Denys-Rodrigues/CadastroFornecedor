using CadastroFornecedor.Data;
using CadastroFornecedor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroFornecedor.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppCont _appCont;

        public CadastroController(AppCont appCont)
        {
            _appCont = appCont;
        }

        //Action sincrona, manda uma RC para o servidor e irá esperar a resposta para continuar.
        public IActionResult Index() // um Método IActionResult espera o retorno de uma view.
        {
            var allTasks = _appCont.Cadastros.ToList();
            // _appCont: caminho do banco,  ToList: seria o select *
            return View(allTasks);
        }

        // GET: Cadastros/Details/5
        public async Task<IActionResult> Details(int? id)// O "?" é para ele aceitar os valores nulos, para não dar B.O no código
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _appCont.Cadastros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // GET: Cadastros/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RazaoSocial,NomeFantasia,Email,Endereco,Contato")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(cadastro);
                await _appCont.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _appCont.Cadastros.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }
            return View(cadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RazaoSocial,NomeFantasia,Email,Endereco,Contato")] Cadastro cadastro)
        {
            if (id != cadastro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appCont.Update(cadastro);
                    await _appCont.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroExist(cadastro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro);
        }

        // GET: Cadastros/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _appCont.Cadastros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastro = await _appCont.Cadastros.FindAsync(id);
            _appCont.Cadastros.Remove(cadastro);
            await _appCont.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroExist(int id)
        {
            return _appCont.Cadastros.Any(e => e.Id == id);
        }
    }
}