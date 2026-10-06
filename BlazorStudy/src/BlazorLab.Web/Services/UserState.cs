namespace BlazorLab.Web.Services;

public class UserState
{
    private string _nome = "Diego";

    public string Nome
    {
        get => _nome;
        set
        {
            if (_nome == value) return;
            _nome = value;
            OnChange?.Invoke();
        }
    }

    public event Action? OnChange;
}
