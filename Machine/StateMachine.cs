namespace Machine;

public class Bubble
{
    public string? Name { get; set; }
}

public interface IState
{
    void PutMoney(decimal amount);
    Bubble Turn();
}

public class StateMachine
{
    private IState _state;
    private List<Bubble> _bubbles;
    private List<decimal> _moneys;

    public StateMachine(IState state, IEnumerable<Bubble> bubbles)
    {
        _state = state;
        _bubbles = bubbles.ToList();
        _moneys = new();
    }
    public void PutMoney(decimal amount)
    {
        _state.PutMoney(amount);
    }
    public Bubble Turn()
    {
        return _state.Turn();
    }

    internal void Attach(IState state)
    {
        _state = state;
    }

    internal void AddMoney(decimal amount)
    {
        _moneys.Add(amount);
    }

    // take an element from the list of bubbles at random position, and remote it from list
    internal Bubble PopBubble()
    {
        var index = new Random().Next(0, _bubbles.Count);
        var bubble = _bubbles[index];
        _bubbles.RemoveAt(index);
        return bubble;
    }
}
