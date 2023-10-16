using Common.Entity;
using EventBus.Messages.EventObjects;

namespace EventBus.Messages.Events
{
    public class SendingPackageEvent : IntegrationBaseEvent
    {
        public string ShippingRequestId { get; set; }
        public string UserId { get; set; }
        public string CourierId { get; set; }
        public AddressEO AddressFrom { get; set; }
        public AddressEO AddressTo { get; set; }
        public bool IsExpress { get; set; }
        public bool IsFinished { get; set; }
        public DateTime DateOfDispatch { get; set; }
        public Status Status { get; set; }

        public PaymentOptionEO PaymentOption { get; set; }
        public ShippingOptionEO ShippingOption { get; set; }
        public BillingEO Billing { get; set; }
        public List<PackageEO> Packages { get; set; }
    }
}
