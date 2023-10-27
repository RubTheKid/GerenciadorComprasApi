using GerenciadorComprasApp.Models;

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace GerenciadorComprasApp.Services;

public class EmpresaService : IEmpresaService
{
    private readonly HttpClient _client;

    public EmpresaService(HttpClient client)
    {


        _client = client;
    }

    public async Task<IEnumerable<Empresa>> GetEmpresasAsync()
    {
        var response = await _client.GetAsync("api/empresas/");


        if (response.IsSuccessStatusCode)
        {
            var empresasJson = await response.Content.ReadAsStringAsync();
            var empresas = JsonSerializer.Deserialize<IEnumerable<Empresa>>(empresasJson);
            return empresas;
        }

        return null;
    }
    public async Task<HttpResponseMessage> AddEmpresaAsync(Empresa novaEmpresa)
    {
        string apiUrl = "https://localhost:7119/api/empresas/";

        var empresaJson = JsonSerializer.Serialize(novaEmpresa);
        var content = new StringContent(empresaJson, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(apiUrl, content);
        return response;
    }


    public async Task<HttpResponseMessage> DeleteAsync(string cnpj)
    {
        string apiUrl = $"https://localhost:7119/api/empresas/{cnpj}";
        var response = await _client.DeleteAsync(apiUrl);
        return response;
    }

}
