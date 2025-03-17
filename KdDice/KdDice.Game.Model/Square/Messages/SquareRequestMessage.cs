namespace KdDice.Game.Model.Square.Messages;

public record SquareRequestMessage(int Number, InstanceInfo InstanceInfo)
{
    public required Guid RequestId { get; set;  }
}