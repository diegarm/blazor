namespace BlazorLab.Application.Models;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Concluida { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public DateTime? DataVencimento { get; set; }
    public string Prioridade { get; set; } = "Média"; // Baixa, Média, Alta
}
