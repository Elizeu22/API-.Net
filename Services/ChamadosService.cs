using CadastroVeiculo.Models;
using CadastroVeiculo.DB;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CadastroVeiculo.Services;




namespace CadastroVeiculo.Services
{

    public class ChamadosService : IChamadoService
    {
        private readonly AberturaChamadoContext _context;

        public ChamadosService(AberturaChamadoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AberturaChamado>> GetChamados()
        {
            try
            {
                return await _context.Chamados.ToListAsync();
            }
            catch
            {
                throw;
            }

        }


        public async Task Chamados(AberturaChamado chamadoAbertura)
        {
            _context.Chamados.Add(chamadoAbertura);
            await _context.SaveChangesAsync();

        }



        public async Task AtualizarChamados(AberturaChamado atualizarChamado)
        {
            _context.Entry(Chamados).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }



        public async Task<AberturaChamado> GetChamado(int id)
        {
            AberturaChamado aberturaChamado = await _context.Chamados.FindAsync(id);
            return aberturaChamado;
        }



        public async Task DeletarChamado(AberturaChamado chamado)
        {
            _context.Chamados.Remove(chamado);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<AberturaChamado>> GetChamadoPlaca(string placaVeiculo)
        {
            if (!string.IsNullOrWhiteSpace(placaVeiculo))
            {
                var chamadosAbertura = await _context.Chamados.Where(x => x.placaVeiculo.Contains(placaVeiculo)).ToListAsync();
                return chamadosAbertura;
            }
            else
            {
                var chamados = await GetChamados();
                return chamados;
            }
        }


    }
}
