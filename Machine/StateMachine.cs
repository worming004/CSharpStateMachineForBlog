namespace Machine;

public class Bubble
{
    public string? Name { get; }

    public Bubble(string? name)
    {
        Name = name;
    }
}

public interface IState
{
    void PutMoney(decimal amount);
    Bubble Turn();
    StateName GetStateName();
}

public enum StateName
{
    Iddle,
    WithMoney
}

public class StateMachine
{
    private IState _state;
    private List<Bubble> _bubbles;
    private List<decimal> _moneys;
    private Random _random;

    public StateMachine(IState state, IEnumerable<Bubble> bubbles, Random? random = null)
    {
        _state = state ?? new IddleState(this);
        _bubbles = bubbles.ToList();
        _moneys = new();
        _random = random ?? new Random();
    }
    public virtual void PutMoney(decimal amount)
    {
        _state.PutMoney(amount);
    }
    public virtual Bubble Turn()
    {
        return _state.Turn();
    }

    internal virtual void Attach(IState state)
    {
        _state = state;
    }

    internal virtual void AddMoney(decimal amount)
    {
        _moneys.Add(amount);
    }

    internal virtual Bubble PopBubble()
    {
        if (_bubbles.Count == 0)
        {
            return null;
        }

        var index = _random.Next(0, _bubbles.Count);
        var bubble = _bubbles[index];
        _bubbles.RemoveAt(index);
        return bubble;
    }

    public virtual StateName GetStateName(){
      return _state.GetStateName();
    }
}
