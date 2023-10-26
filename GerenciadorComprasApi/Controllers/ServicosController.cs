using GerenciadorComprasApi.Models.Domain;
using GerenciadorComprasApi.Models.ViewModels.Produto;
using GerenciadorComprasApi.Models.ViewModels.Servico;
using GerenciadorComprasApi.Repositories.Produtos;
using GerenciadorComprasApi.Repositories.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorComprasApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicosController : ControllerBase
{
    private readonly IServicoRepository servicoRepository;
    public ServicosController(IServicoRepository servicoRepository)
    {
        this.servicoRepository = servicoRepository;
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddServicoRequest addServicoRequest)
    {
        var servico = new Servico
        {
            CodigoServico = addServicoRequest.CodigoServico,
            Nome = addServicoRequest.Nome,
            Descricao = addServicoRequest.Descricao,
            PrazoEntrega = addServicoRequest.PrazoEntrega,

        };
        await servicoRepository.AddAsync(servico);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var servicos = await servicoRepository.GetAllAsync();

        return Ok(servicos);
    }

    [HttpGet("{codigoServico}")]
    public async Task<IActionResult> Get(string codigoServico)
    {
        var servico = await servicoRepository.GetAsync(codigoServico);

        if (servico != null)
        {
            return Ok(servico);
        }

        return NotFound();
    }


    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] EditServicoRequest getServico)
    {
        var servico = new Servico
        {
            CodigoServico = getServico.CodigoServico,
            Nome = getServico.Nome,
            Descricao = getServico.Descricao,
            PrazoEntrega = getServico.PrazoEntrega,
        };

        var updateServico = await servicoRepository.UpdateAsync(servico);

        if (updateServico == null)
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpDelete("{codigoServico}")]
    public async Task<IActionResult> Delete(string codigoServico)
    {
        var deleteServico = await servicoRepository.DeleteAsync(codigoServico);

        if (deleteServico == null)
        {
            return NotFound();
        }

        return Ok();
    }
}
