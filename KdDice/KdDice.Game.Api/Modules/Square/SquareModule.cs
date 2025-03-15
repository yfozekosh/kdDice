namespace KdDice.Game.Api.Modules.Square;

public static class SquareModule
{
    public static void UseSquareModule(this WebApplication application)
    {
        application.AddSquareApiEndpoint();
    }
}