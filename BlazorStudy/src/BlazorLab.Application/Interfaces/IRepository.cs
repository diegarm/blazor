namespace BlazorLab.Application.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> ObterTodosAsync();
    Task<T?> ObterPorIdAsync(int id);
    Task<T> AdicionarAsync(T entity);
    Task<bool> AtualizarAsync(T entity);
    Task<bool> DeletarAsync(int id);
    Task<int> SalvarAlteracoesAsync();
}
