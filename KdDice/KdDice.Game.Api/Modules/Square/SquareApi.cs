using KdDice.Game.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using KdDice.Game.Model.Square.Messages;

namespace KdDice.Game.Api.Modules.Square;

public static class SquareApi
{
    public static void AddSquareApiEndpoint(this WebApplication builder)
    {
        builder.MapPost(
                "/v1/square/{number:int}",
                async ([FromRoute] int number, [FromServices] IPublishEndpoint publishEndpoint) =>
                {
                    var squareRequestMessage = new SquareRequestMessage(number, VersionInfo.Instance)
                    {
                        RequestId = Guid.NewGuid()
                    };
                    await publishEndpoint.Publish(squareRequestMessage);

                    return Results.Ok(new
                    {
                        Response = "Request has been created",
                        squareRequestMessage.RequestId
                    });
                })
            .WithName("PublishSquare")
            .WithOpenApi();
    }
}