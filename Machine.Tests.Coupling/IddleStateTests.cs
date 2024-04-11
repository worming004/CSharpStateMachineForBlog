using Machine;

namespace Machine.Tests.Coupling;

public class IddleStateTests
{
    private class NullMachine : StateMachine
    {
        internal NullMachine() : base(null, new List<Bubble>(), null)
        {
        }
        public IState ReceivedState { get; private set; }
        public override void PutMoney(decimal amount)
        {
        }
        public override Bubble Turn()
        {
            return null;
        }
        internal override void Attach(IState state)
        {
            ReceivedState = state;
        }
        internal override void AddMoney(decimal amount)
        {
        }
        internal Bubble PopBubble()
        {
            return null;
        }
    }
    [Fact]
    public void IddleState_AcceptMoney_ShouldChangeStateToWithMoney()
    {
        // Arrange
        var numMachine = new NullMachine();
        var iddleState = new IddleState(numMachine);

        // Act
        iddleState.PutMoney(10);

        // Assert
        Assert.Equal(numMachine.ReceivedState.GetType(), typeof(WithMoneyState));
    }
}
