namespace ScopedServiceEvent
{
    public class CounterState
    {
        private int count = 0;

        public int Count => count;

        public event Action? OnChange;

        public void Increment()
        {
            count++;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
