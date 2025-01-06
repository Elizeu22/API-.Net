using CadastroVeiculo.Models;
using CadastroVeiculo.DB;
using CadastroVeiculo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace CadastroVeiculo.Controllers
{
    [Route("colaborador/[controller]")]
    [ApiController]
    public class ColaboradorController: ControllerBase
    {

        private readonly IColaboradorService _colaboradorService;

        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }


        [HttpGet(Name = "ListarColaboradores")]
        public async Task<ActionResult<IEnumerable<Colaborador>>> ListarColaborador()
        {
            try
            {
                var colaboradores = await _colaboradorService.GetColaboradores();
                return Ok(colaboradores);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar od dados");
            }
        }



        [HttpGet("{numeroColaborador:int}", Name = "IdColaborador")]
        public async Task<ActionResult<Colaborador>> ProcurarChamado(int numeroColaborador)
        {
            var idChamados = await _colaboradorService.GetColaborador(numeroColaborador);


            if (idChamados == null) return NotFound($"Dados nao foram enconstrados id: {numeroColaborador}");

            return Ok(idChamados);


        }



        [HttpPost(Name = "CadastrarColaborador")]
        public async Task<ActionResult> aberturaChamado(Colaborador colaborador)
        {
            try
            {
                await _colaboradorService.PostColaboradores(colaborador);
                return CreatedAtRoute("ListarChamado", new { id = colaborador.id }, colaborador);
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }




        [HttpPut("{idColaborador:int}")]
        public async Task<ActionResult> AtualizarChamado(int idColaborador, [FromBody] Colaborador colaborador)
        {
            try
            {
                if (colaborador.id == idColaborador)
                {
                    await _colaboradorService.PutAtualizarColaborador(colaborador);
                    return CreatedAtRoute("GetChamado", new { idChamado = colaborador.id }, colaborador);
                }
                else
                {
                    return BadRequest("Dados Invalidos");
                }


            }
            catch (Exception)
            {
                return BadRequest("Request Invalido");

            }
        }


        [HttpDelete("{idColaborador:int}")]
        public async Task<ActionResult> DeletarChamdo(int idColaborador)
        {
            try
            {
                var chamadoColaborador = await _colaboradorService.GetColaborador(idColaborador);

                if (chamadoColaborador != null)
                {
                    await _colaboradorService.DeletarColaborador(chamadoColaborador);
                    return Ok(chamadoColaborador);
                }
                else
                {
                    return BadRequest($"Dados nao encontrados:{idColaborador}");
                }
            }
            catch
            {
                return BadRequest("REQUEST iNVVALIDA");
            }
        }




    }
}
