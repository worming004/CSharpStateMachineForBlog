namespace Machine;

internal class IddleState : IState
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
        _machine.Attach(new WithMoneyState(_machine));
    }

    public Bubble Turn()
    {
        // Nothing
        return null;
    }

    public StateName GetStateName()
    {
        return StateName.Iddle;
    }
}


