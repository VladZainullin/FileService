using Application.Common.Interfaces;

namespace Web.Middlewares;

internal sealed class TransactionMiddleware : IMiddleware
{
    private readonly ITransactionExecutor _transactionExecutor;

    public TransactionMiddleware(ITransactionExecutor transactionExecutor)
    {
        _transactionExecutor = transactionExecutor;
    }
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var cancellationToken = context.RequestAborted;

        await using var transaction = await _transactionExecutor.BeginTransactionAsync(cancellationToken);
        try
        {
            await next(context);
            
            await transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}