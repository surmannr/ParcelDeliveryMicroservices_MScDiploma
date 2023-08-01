using MediatR;

namespace Common.Extension.CQRS
{
    public interface ICommand<TResult> : IRequest<TResult>
    {
    }
}
