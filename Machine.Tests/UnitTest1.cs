namespace Machine.Tests;

public class UnitTest1
{
    [Fact]
    public void MachineOnIddleState_AcceptMoney_ShouldChangeStateToWithMoney()
    {
        // Arrange
        var machine = new StateMachine(null, new List<Bubble>() { new Bubble("Charizard") }, null);

        // Act
        machine.PutMoney(10);

        // Assert
        Assert.Equal(StateName.WithMoney, machine.GetStateName());

    }
}
