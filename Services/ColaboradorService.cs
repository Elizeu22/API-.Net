using CadastroVeiculo.Models;
using CadastroVeiculo.DB;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CadastroVeiculo.Services;





namespace CadastroVeiculo.Services
{
    public class ColaboradorService:IColaboradorService
    {
        private readonly AberturaChamadoContext _context;

        public ColaboradorService(AberturaChamadoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Colaborador>> GetColaboradores()
        {
            try
            {
                return await _context.Colaboradores.ToListAsync();
            }
            catch
            {
                throw;
            }

        }


        public async Task PostColaboradores(Colaborador funcionario)
        {
            _context.Colaboradores.Add(funcionario);
            await _context.SaveChangesAsync();

        }



        public async Task PutAtualizarColaborador(Colaborador atualizarColaborador)
        {
            _context.Entry(atualizarColaborador).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }



        public async Task<Colaborador> GetColaborador(int id)
        {
            Colaborador idColaborador = await _context.Colaboradores.FindAsync(id);
            return idColaborador;
        }



        public async Task DeletarColaborador(Colaborador deletarColaborador)
        {
            _context.Colaboradores.Remove(deletarColaborador);
            await _context.SaveChangesAsync();
        }


  
    }
}
