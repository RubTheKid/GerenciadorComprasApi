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
            Cnpj = addEmpresaRequest.Cnpj,
            Nome = addEmpresaRequest.Nome,
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

    [HttpGet("{cnpj}")]
    [ActionName("Get")]
    public async Task<IActionResult> Get(string cnpj)
    {
        var empresa = await empresaRepository.GetAsync(cnpj);

        if (empresa != null)
        {
            return Ok(empresa);
        }

        return NotFound();
    }

    //[HttpGet("cnpj/{cnpj}")]
    //[ActionName("GetByCnpj")]
    //public async Task<IActionResult> GetByCnpj(string cnpj)
    //{
    //    var empresa = await empresaRepository.GetByCnpjAsync(cnpj);

    //    if (empresa != null)
    //    {
    //        return Ok(empresa);
    //    }

    //    return NotFound();
    //}

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
            Cnpj = getEmpresa.Cnpj,
            Nome = getEmpresa.Nome,
            
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

    [HttpDelete("{cnpj}")]
    [ActionName("Delete")]
    public async Task<ActionResult> Delete(string cnpj)
    {
        var deleteEmpresa = await empresaRepository.DeleteAsync(cnpj);

        if (deleteEmpresa == null)
        {
            return NotFound();
        }

        return Ok();
    }
}