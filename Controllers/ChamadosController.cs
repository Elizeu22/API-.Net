using CadastroVeiculo.Models;
using CadastroVeiculo.DB;
using CadastroVeiculo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace CadastroVeiculo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChamadosController: ControllerBase
    {
        private readonly IChamadoService _chamadoService;

        public ChamadosController(IChamadoService chamadoService)
        {
            _chamadoService = chamadoService;
        }




        [HttpGet(Name ="Listarchamados")]
        public async Task<ActionResult<IEnumerable<AberturaChamado>>> ListarChamado()
        {
            try
            {
                var chamados = await _chamadoService.GetChamados();
                return Ok(chamados);
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar od dados");
            }
        }


        [HttpGet("{numeroChamado:int}", Name="IdChamado")]
        public async Task<ActionResult<AberturaChamado>> ProcurarChamado(int numeroChamado)
        {
                var idChamados = await _chamadoService.GetChamado(numeroChamado);
               

            if(idChamados == null)  return NotFound($"Dados nao foram enconstrados id: {numeroChamado}");

            return Ok(idChamados);


        }


        [HttpPost(Name ="CadastrarChamados")]
        public async Task<ActionResult> aberturaChamado(AberturaChamado chamado)
        {
            try
            {
                await _chamadoService.Chamados(chamado);
                return CreatedAtRoute("ListarChamado", new { id = chamado.id }, chamado);
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }


        [HttpGet("VeiculoPlaca")]
        public async Task<ActionResult<IEnumerable<AberturaChamado>>> getPlaca([FromQuery] string placa)
        {
            var veiculoPlaca = await _chamadoService.GetChamadoPlaca(placa);

            if(veiculoPlaca == null)
            {
                return NotFound($"Placa nao encontrada: {placa}");
            }


            return Ok(veiculoPlaca);
        }


        [HttpPut("{idChamado:int}")]
        public async Task <ActionResult>AtualizarChamado(int idChamado, [FromBody] AberturaChamado chamado)
        {
            try
            {
                if(chamado.id == idChamado)
                {
                    await _chamadoService.AtualizarChamados(chamado);
                    return CreatedAtRoute("GetChamado", new { idChamado = chamado.id }, chamado);
                }
                else
                {
                    return BadRequest("Dados Invalidos");
                }

               
            }
            catch(Exception)
            {
                return BadRequest("Request Invalido");

            }
        }


        [HttpDelete("{idChamado:int}")]
        public async Task<ActionResult>DeletarChamdo(int idChamado)
        {
            try
            {
                var chamadoAbertura = await _chamadoService.GetChamado(idChamado);

                if(chamadoAbertura != null)
                {
                    await _chamadoService.DeletarChamado(chamadoAbertura);
                  return Ok(chamadoAbertura);
                }
                else
                {
                    return BadRequest($"Dados nao encontrados:{idChamado}");
                }
            }
            catch
            {
                return BadRequest("REQUEST iNVVALIDA");
            }
        }








    }
}
