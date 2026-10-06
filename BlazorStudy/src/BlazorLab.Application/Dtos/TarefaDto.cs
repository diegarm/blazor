namespace BlazorLab.Application.Dtos;

public class CreateTarefaDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public DateTime? DataVencimento { get; set; }
    public string Prioridade { get; set; } = "Média";
}

public class UpdateTarefaDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Concluida { get; set; }
    public DateTime? DataVencimento { get; set; }
    public string Prioridade { get; set; } = "Média";
}

public class TarefaDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Concluida { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataVencimento { get; set; }
    public string Prioridade { get; set; } = "Média";
}
