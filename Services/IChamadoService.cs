using CadastroVeiculo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CadastroVeiculo.Services
{
    public interface IChamadoService
    {
        Task<IEnumerable<AberturaChamado>> GetChamados();
        Task<AberturaChamado> GetChamado(int id);
        Task<IEnumerable<AberturaChamado>> GetChamadoPlaca(string placa);
        Task Chamados(AberturaChamado chamados);
        Task AtualizarChamados(AberturaChamado chamados);
        Task DeletarChamado(AberturaChamado chamados);
    }
}
