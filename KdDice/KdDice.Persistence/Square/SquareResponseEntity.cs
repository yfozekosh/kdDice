namespace KdDice.Persistence.Square;

public class SquareResponseEntity
{
    public Guid InstanceId { get; set; }

    public int Result { get; set; }

    public Guid RequestId { get; set; }

    public Guid ResponseId { get; set; }
}