using BlazorLab.Application.Dtos;
using BlazorLab.Application.Interfaces;
using BlazorLab.Application.Models;

namespace BlazorLab.Infrastructure.Services;

public class TarefaService : ITarefaService
{
    private readonly IRepository<Tarefa> _repository;

    public TarefaService(IRepository<Tarefa> repository)
    {
        _repository = repository;
    }

    public async Task<List<TarefaDto>> ObterTarefasAsync()
    {
        var tarefas = await _repository.ObterTodosAsync();
        return tarefas.Select(MapToDto).ToList();
    }

    public async Task<TarefaDto?> ObterTarefaPorIdAsync(int id)
    {
        var tarefa = await _repository.ObterPorIdAsync(id);
        return tarefa == null ? null : MapToDto(tarefa);
    }

    public async Task<TarefaDto> CriarTarefaAsync(CreateTarefaDto dto)
    {
        var tarefa = new Tarefa
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            DataVencimento = dto.DataVencimento,
            Prioridade = dto.Prioridade,
            Concluida = false,
            DataCriacao = DateTime.UtcNow
        };

        await _repository.AdicionarAsync(tarefa);
        await _repository.SalvarAlteracoesAsync();
        
        return MapToDto(tarefa);
    }

    public async Task<bool> AtualizarTarefaAsync(UpdateTarefaDto dto)
    {
        var tarefa = await _repository.ObterPorIdAsync(dto.Id);
        if (tarefa == null)
            return false;

        tarefa.Titulo = dto.Titulo;
        tarefa.Descricao = dto.Descricao;
        tarefa.Concluida = dto.Concluida;
        tarefa.DataVencimento = dto.DataVencimento;
        tarefa.Prioridade = dto.Prioridade;

        return await _repository.AtualizarAsync(tarefa);
    }

    public async Task<bool> DeletarTarefaAsync(int id)
    {
        return await _repository.DeletarAsync(id);
    }

    public async Task<bool> AlternarConclusaoAsync(int id)
    {
        var tarefa = await _repository.ObterPorIdAsync(id);
        if (tarefa == null)
            return false;

        tarefa.Concluida = !tarefa.Concluida;
        return await _repository.AtualizarAsync(tarefa);
    }

    private TarefaDto MapToDto(Tarefa tarefa)
    {
        return new TarefaDto
        {
            Id = tarefa.Id,
            Titulo = tarefa.Titulo,
            Descricao = tarefa.Descricao,
            Concluida = tarefa.Concluida,
            DataCriacao = tarefa.DataCriacao,
            DataVencimento = tarefa.DataVencimento,
            Prioridade = tarefa.Prioridade
        };
    }
}
