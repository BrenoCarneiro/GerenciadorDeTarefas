using Microsoft.EntityFrameworkCore;
using GerenciadorDeTarefas.Models;

namespace GerenciadorDeTarefas.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
