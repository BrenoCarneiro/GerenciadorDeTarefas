using Microsoft.AspNetCore.Mvc;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Context;

namespace GerenciadorDeTarefas.Controllers
{
    public class TarefaController : Controller
    {
        
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tarefas = _context.Tarefas.ToList();
            return View(tarefas);
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefas)
        {
            if (ModelState.IsValid)
            {
                _context.Tarefas.Add(tarefas);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tarefas);
        }

        public IActionResult Editar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(tarefa);
            }
        }
        [HttpPost]
        public IActionResult Editar(Tarefa tarefas)
        {
            var tarefaDoBanco = _context.Tarefas.Find(tarefas.Id);

            tarefaDoBanco.Titulo = tarefas.Titulo;
            tarefaDoBanco.Descricao = tarefas.Descricao;
            tarefaDoBanco.Data = tarefas.Data;
            tarefaDoBanco.Status = tarefas.Status;

            _context.Tarefas.Update(tarefaDoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(tarefa);
            }
        }

        public IActionResult Deletar(int id)
        {
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(tarefa);
            }
        }

        [HttpPost]
        public IActionResult Deletar(Tarefa tarefas)
        {
            var tarefaDoBanco = _context.Tarefas.Find(tarefas.Id);

            _context.Tarefas.Remove(tarefaDoBanco);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
