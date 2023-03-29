using MediatR;

namespace PackageSending.BL.Extensions.CQRS
{
    public interface ICommand<TResult> : IRequest<TResult>
    {
    }
}