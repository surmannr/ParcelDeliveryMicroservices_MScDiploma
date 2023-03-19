using MediatR;

namespace PackageDelivery.BL.Extensions.CQRS
{
    public interface ICommand<TResult> : IRequest<TResult>
    {
    }
}