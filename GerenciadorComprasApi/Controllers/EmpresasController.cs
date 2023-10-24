using GerenciadorComprasApi.Models.Domain;
using GerenciadorComprasApi.Models.ViewModels.Empresa;
using GerenciadorComprasApi.Repositories.Empresas;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorComprasApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpresasController : ControllerBase
{
    private readonly IEmpresaRepository empresaRepository;

    public EmpresasController(IEmpresaRepository empresaRepository)
    {
        this.empresaRepository = empresaRepository;
    }

    [HttpPost]
    public async Task<ActionResult> Add(AddEmpresaRequest addEmpresaRequest)
    {
        var empresa = new Empresa
        {
            Nome = addEmpresaRequest.Nome,
            Cnpj = addEmpresaRequest.Cnpj,
            Email = addEmpresaRequest.Email,
            InscricaoEstadual = addEmpresaRequest.InscricaoEstadual,
            InscricaoMunicipal = addEmpresaRequest.InscricaoMunicipal
        };

        await empresaRepository.AddAsync(empresa);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> List()
    {
        var empresas = await empresaRepository.GetAllAsync();

        return Ok(empresas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Edit(Guid id)
    {
        var empresa = await empresaRepository.GetAsync(id);

        if (empresa == null)
        {
            return NotFound();
        }

        var editEmpresa = new EditEmpresaRequest
        {
            Id = empresa.Id,
            Nome = empresa.Nome,
            Cnpj = empresa.Cnpj,
            Email = empresa.Email,
            InscricaoEstadual = empresa.InscricaoEstadual,
            InscricaoMunicipal = empresa.InscricaoMunicipal
        };

        return Ok(editEmpresa);
    }

    [HttpPut]
    public async Task<ActionResult> Edit(EditEmpresaRequest getEmpresa)
    {
        var empresa = new Empresa
        {
            Id = getEmpresa.Id,
            Nome = getEmpresa.Nome,
            Cnpj = getEmpresa.Cnpj,
            Email = getEmpresa.Email,
            InscricaoEstadual = getEmpresa.InscricaoEstadual,
            InscricaoMunicipal = getEmpresa.InscricaoMunicipal
        };

        var updatedEmpresa = await empresaRepository.UpdateAsync(empresa);

        if (updatedEmpresa == null)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var deleteEmpresa = await empresaRepository.DeleteAsync(id);

        if (deleteEmpresa == null)
        {
            return NotFound();
        }

        return Ok();
    }
}