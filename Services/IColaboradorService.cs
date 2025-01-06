using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CadastroVeiculo.Models;





namespace CadastroVeiculo.Services
{
    public interface IColaboradorService
    {
        Task<IEnumerable<Colaborador>> GetColaboradores();
        Task<Colaborador> GetColaborador(int id);
        Task PostColaboradores(Colaborador chamados);
        Task PutAtualizarColaborador(Colaborador chamados);
        Task DeletarColaborador(Colaborador chamados);
    }
}
