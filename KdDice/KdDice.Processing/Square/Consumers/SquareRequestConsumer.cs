using KdDice.Game.Model;
using KdDice.Game.Model.Square.Messages;
using KdDice.Persistence;
using KdDice.Persistence.Square;
using MassTransit;

namespace KdDice.Processing.Square.Consumers;

public class SquareRequestConsumer(MongoDbContext mongoContext) : IConsumer<SquareRequestMessage>
{
    public async Task Consume(ConsumeContext<SquareRequestMessage> context)
    {
        var message = context.Message;

        await mongoContext.SquareResponses.InsertOneAsync(
            new SquareResponseEntity
            {
                InstanceId = VersionInfo.Instance.InstanceId,
                RequestId = message.RequestId,
                Result = message.Number * 2,
                ResponseId = Guid.NewGuid()
            },
            cancellationToken: context.CancellationToken);
    }
}