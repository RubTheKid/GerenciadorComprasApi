using GerenciadorComprasApi.Models.Domain;
using GerenciadorComprasApi.Models.ViewModels.Produto;
using GerenciadorComprasApi.Models.ViewModels.Servico;
using GerenciadorComprasApi.Repositories.Produtos;
using GerenciadorComprasApi.Repositories.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorComprasApi.Controllers;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var servico = await servicoRepository.GetAsync(id);

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
            Id = getServico.Id,
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteServico = await servicoRepository.DeleteAsync(id);

        if (deleteServico == null)
        {
            return NotFound();
        }

        return Ok();
    }
}
