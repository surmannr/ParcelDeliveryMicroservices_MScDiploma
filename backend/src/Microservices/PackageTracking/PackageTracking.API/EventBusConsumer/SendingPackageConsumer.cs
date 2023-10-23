using AutoMapper;
using Common.Dto;
using EventBus.Messages.Events;
using MassTransit;
using PackageTracking.DAL.Repositories;

namespace PackageTracking.API.EventBusConsumer
{
    public class SendingPackageConsumer : IConsumer<SendingPackageEvent>
    {
        private readonly IPackageTrackingRepository _repository;
        private readonly IMapper _mapper;
        public SendingPackageConsumer(IPackageTrackingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<SendingPackageEvent> context)
        {
            var shipping = _mapper.Map<ShippingRequestDto>(context.Message);
            shipping.Billing.Currency = _mapper.Map<CurrencyDto>(context.Message.Billing.Currency);
            shipping.Id = context.Message.ShippingRequestId;
            await _repository.UpdateShipping(shipping);
        }
    }
}
