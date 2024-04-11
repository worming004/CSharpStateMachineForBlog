namespace Machine.Tests;

public class StateMachineTests
{
    private class NotRandom : Random
    {
        public int NextRandom { get; set; }
        public override int Next(int maxValue) => NextRandom;
    }

    [Fact]
    public void Machine_AcceptMoney_ShouldChangeStateToWithMoney()
    {
        // Arrange
        var machine = new StateMachine(null, new List<Bubble>() { new Bubble("Charizard") }, null);

        // Act
        machine.PutMoney(10);

        // Assert
        Assert.Equal(StateName.WithMoney, machine.GetStateName());
    }

    [Fact]
    public void Machine_Turn_GotABubble()
    {
        // Arrange
        var notRandom = new NotRandom { NextRandom = 1 };
        var bubbles = new List<Bubble>() { new Bubble("Charizard"), new Bubble("Mewtwo") };
        var expectedBubble = bubbles[1];
        var machine = new StateMachine(null, bubbles, notRandom);
        try
        {
            machine.PutMoney(10);
            Assert.Equal(StateName.WithMoney, machine.GetStateName());
        }
        catch (Exception ex)
        {
            throw new Exception("Cannot put state in wanted state", ex);
        }

        // Act
        var gotBubble = machine.Turn();

        // Assert
        Assert.Equal(StateName.Iddle, machine.GetStateName());
        Assert.Equal(expectedBubble, gotBubble);
    }

    [Fact]
    // This is actually the test I'll favor the most. It test a full user case
    public void Machine_WholeUseCase_UserPutMoney_GotBubbles()
    {
        // Arrange
        var notRandom = new NotRandom { NextRandom = 1 };
        var bubbles = new List<Bubble>() { new Bubble("Charizard"), new Bubble("Mewtwo") };
        var expectedBubble = bubbles[1];
        var machine = new StateMachine(null, bubbles, notRandom);

        machine.PutMoney(10);
        var gotBubble = machine.Turn();

        Assert.Equal(expectedBubble, gotBubble);
    }
}
