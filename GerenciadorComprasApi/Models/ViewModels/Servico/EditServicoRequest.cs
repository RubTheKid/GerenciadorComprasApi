﻿namespace GerenciadorComprasApi.Models.ViewModels.Servico;

public class EditServicoRequest
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public int? PrazoEntrega { get; set; }
}
