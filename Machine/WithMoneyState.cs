namespace Machine;

public class WithMoneyState : IState
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
        return bubble;
    }
}
