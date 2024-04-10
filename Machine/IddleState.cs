namespace Machine;

public class IddleState : IState
{
    private StateMachine _machine;

    public IddleState(StateMachine machine)
    {
        _machine = machine;
        _machine.Attach(this);
    }

    public void PutMoney(decimal amount)
    {
        _machine.AddMoney(amount);
    }

    public Bubble Turn()
    {
        // Nothing
        return null;
    }
}


