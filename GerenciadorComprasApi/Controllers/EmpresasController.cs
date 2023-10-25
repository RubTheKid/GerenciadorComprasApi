using GerenciadorComprasApi.Models.Domain;
using GerenciadorComprasApi.Models.ViewModels.Empresa;
using GerenciadorComprasApi.Repositories.Empresas;
using GerenciadorComprasApi.Repositories.Produtos;
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
    [ActionName("Add")]
    public async Task<ActionResult> Add(AddEmpresaRequest addEmpresaRequest)
    {
        if (addEmpresaRequest == null)
        {
            return BadRequest("A solicitação não pode ser nula");
        }

        var empresaExists = await empresaRepository.GetByCnpjAsync(addEmpresaRequest.Cnpj);
        if (empresaExists != null)
        {
            return BadRequest("CNPJ já cadastrado.");
        }
        
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
    [ActionName("List")]
    public async Task<ActionResult> List()
    {
        var empresas = await empresaRepository.GetAllAsync();

        return Ok(empresas);
    }

    [HttpGet("{id}")]
    [ActionName("Get")]
    public async Task<IActionResult> Get(Guid id)
    {
        var empresa = await empresaRepository.GetAsync(id);

        if (empresa != null)
        {
            return Ok(empresa);
        }

        return NotFound();
    }

    [HttpGet("cnpj/{cnpj}")]
    [ActionName("GetByCnpj")]
    public async Task<IActionResult> GetByCnpj(string cnpj)
    {
        var empresa = await empresaRepository.GetByCnpjAsync(cnpj);

        if (empresa != null)
        {
            return Ok(empresa);
        }

        return NotFound();
    }

    [HttpPut]
    [ActionName("Edit")]
    public async Task<ActionResult> Edit(EditEmpresaRequest getEmpresa)
    {
        if (getEmpresa == null)
        {
            return BadRequest("A solicitação não pode ser nula.");
        }

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
            return BadRequest("A atualização falhou");
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    [ActionName("Delete")]
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