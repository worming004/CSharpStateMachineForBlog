namespace Machine;

internal class WithMoneyState : IState
{
    private StateMachine _machine;

    public WithMoneyState(StateMachine machine)
    {
        _machine = machine;
        _machine.Attach(this);
    }

    public void PutMoney(decimal amount)
    {
        // Nothing
    }

    public Bubble Turn()
    {
        var bubble = _machine.PopBubble();
        _machine.Attach(new IddleState(_machine));
        return bubble;
    }

    public StateName GetStateName()
    {
        return StateName.WithMoney;
    }
}
