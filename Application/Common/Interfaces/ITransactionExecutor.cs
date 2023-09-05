using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Common.Interfaces;

public interface ITransactionExecutor
{
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
}