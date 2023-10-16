using AutoMapper;
using Common.Dto;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using PackageDelivery.BL.Features._ShippingRequest.Commands;

namespace PackageDelivery.API.EventBusConsumer
{
    public class SendingPackageConsumer : IConsumer<SendingPackageEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public SendingPackageConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<SendingPackageEvent> context)
        {
            var shipping = _mapper.Map<ShippingRequestDto>(context);
            shipping.Id = context.Message.ShippingRequestId;
            await _mediator.Send(new AddNewShippingRequest.Command()
            { 
                NewShippingRequest = shipping,
            });
        }
    }
}
