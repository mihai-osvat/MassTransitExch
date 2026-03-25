using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MassTransitExch.Common.Infrastructure.Outbox;

public sealed class InsertOutboxMessageInterceptor() : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
