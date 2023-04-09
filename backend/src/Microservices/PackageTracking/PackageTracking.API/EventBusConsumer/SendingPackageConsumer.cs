using AutoMapper;
using Common.Entity;
using Common.Extension;
using EventBus.Messages.Events;
using MassTransit;
using PackageTracking.DAL.Entities;
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
            var shipping = _mapper.Map<Shipping>(context.Message);
            shipping.Id = context.Message.ShippingRequestId;
            shipping.SenderInformation = new Sender()
            {
                SenderUserId = context.Message.UserId
            };
            shipping.PaymentOptionName = context.Message.PaymentOption.Name;
            shipping.ShippingOptionName = context.Message.ShippingOption.Name;
            shipping.ShippingOptionPrice = context.Message.ShippingOption.Price;
            shipping.Status = Status.Processing.GetDisplayName();
            await _repository.UpdateShipping(shipping);
        }
    }
}
