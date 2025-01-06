using CadastroVeiculo.Models;
using Microsoft.EntityFrameworkCore;



namespace CadastroVeiculo.DB

{
    public class AberturaChamadoContext:DbContext
    {
        public AberturaChamadoContext(DbContextOptions<AberturaChamadoContext> options) : base(options) { }

        public DbSet<AberturaChamado> Chamados { get; set; }

        public DbSet<Colaborador> Colaboradores { get; set; }
    }
}
