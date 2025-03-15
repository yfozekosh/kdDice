namespace KdDice.Game.Api.Modules.Square.Messages;

internal record SquareRequestMessage(int Number)
{
    public Guid Instance { get; } = VersionInfo.InstanceId;

    public Guid RequestId { get; } = Guid.NewGuid();
}