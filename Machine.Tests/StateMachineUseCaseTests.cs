namespace Machine.Tests;

public class StateMachineUseCaseTests
{
    private class NotRandom : Random
    {
        public int NextRandom { get; set; }
        public override int Next(int maxValue) => NextRandom;
    }

    private NotRandom notRandom;
    private List<Bubble> bubbles;
    private StateMachine machine;

    public StateMachineUseCaseTests()
    {

        notRandom = new NotRandom { NextRandom = 1 };
        bubbles = new List<Bubble>() { new Bubble("Charizard"), new Bubble("Mewtwo") };
        machine = StateMachine.New(bubbles, notRandom);
    }

    [Fact]
    public void Machine_WholeUseCase_UserPutMoney_GotBubbles()
    {
        var expectedBubble = bubbles[1];
        notRandom.NextRandom = 1;
        machine.PutMoney(10);
        var gotBubble = machine.Turn();

        // Assert 2
        Assert.Equal(expectedBubble, gotBubble);
    }

    [Fact]
    public void Machine_UserCannotGetBubbleWithoutPuttingMoney()
    {
        var gotBubble = machine.Turn();
        Assert.Equal(null, gotBubble);
    }
}
