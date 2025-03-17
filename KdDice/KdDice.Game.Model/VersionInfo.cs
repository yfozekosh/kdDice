namespace KdDice.Game.Model;

public static class VersionInfo
{
    public static InstanceInfo Instance { get; } = new InstanceInfo(Guid.NewGuid());
}