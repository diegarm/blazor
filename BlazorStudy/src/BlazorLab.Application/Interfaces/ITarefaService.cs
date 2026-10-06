using BlazorLab.Application.Dtos;

namespace BlazorLab.Application.Interfaces;

public interface ITarefaService
{
    Task<List<TarefaDto>> ObterTarefasAsync();
    Task<TarefaDto?> ObterTarefaPorIdAsync(int id);
    Task<TarefaDto> CriarTarefaAsync(CreateTarefaDto dto);
    Task<bool> AtualizarTarefaAsync(UpdateTarefaDto dto);
    Task<bool> DeletarTarefaAsync(int id);
    Task<bool> AlternarConclusaoAsync(int id);
}
