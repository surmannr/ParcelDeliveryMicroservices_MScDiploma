using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageSending.Tests
{
    public static class SeedData
    {
        #region Currencies
        public static Currency Currency1 { get; set; } = new Currency()
        {
            Id = 1,
            Name = "Forint",
        };
        public static Currency Currency2 { get; set; } = new Currency()
        {
            Id = 2,
            Name = "Euró",
        };
        #endregion

        #region PaymentOptions
        public static PaymentOption PaymentOption1 { get; set; } = new PaymentOption()
        {
            Id = 1,
            Name = "Bankkártya",
        };
        public static PaymentOption PaymentOption2 { get; set; } = new PaymentOption()
        {
            Id = 2,
            Name = "Készpénz",
        };
        #endregion

        #region ShippingOptions
        public static ShippingOption ShippingOption1 { get; set; } = new ShippingOption()
        {
            Id = 1,
            Name = "Teherautó",
            Price = 5000,
        };
        public static ShippingOption ShippingOption2 { get; set; } = new ShippingOption()
        {
            Id = 2,
            Name = "Személyes átvétel",
            Price = 0
        };
        #endregion

        #region Packages
        public static Package Package1 { get; set; } = new Package()
        {
            Id = "pid1",
            IsFragile = true,
            SizeX = 1,
            SizeY = 1,
            SizeZ = 1,
            Weight = 2,
            UserId = "teszt1",
            ShippingRequestId = "sid1",
        };
        public static Package Package2 { get; set; } = new Package()
        {
            Id = "pid2",
            IsFragile = false,
            SizeX = 2,
            SizeY = 2,
            SizeZ = 2,
            Weight = 3,
            UserId = "teszt1",
            ShippingRequestId = "sid1",
        };
        public static Package Package3 { get; set; } = new Package()
        {
            Id = "pid3",
            IsFragile = true,
            SizeX = 3,
            SizeY = 3,
            SizeZ = 3,
            Weight = 4,
            UserId = "teszt2",
            ShippingRequestId = "sid2",
        };
        public static Package Package4 { get; set; } = new Package()
        {
            Id = "pid4",
            IsFragile = false,
            SizeX = 4,
            SizeY = 4,
            SizeZ = 5,
            Weight = 6,
            UserId = "teszt2",
            ShippingRequestId = "sid2",
        };
        #endregion

        #region Billings
        public static Billing Billing1 { get; set; } = new Billing()
        {
            Id = "bid1",
            CurrencyId = 1,
            Currency = Currency1,
            Name = "Teszt Elek",
            UserId = "teszt1",
            TotalAmount = 20000,
            TotalDistance = 100,
            ShippingRequest = new ShippingRequest()
        };
        public static Billing Billing2 { get; set; } = new Billing()
        {
            Id = "bid2",
            CurrencyId = 2,
            Currency = Currency2,
            Name = "Teszt2 Elek",
            UserId = "teszt2",
            TotalAmount = 35200,
            TotalDistance = 143,
            ShippingRequest = new ShippingRequest()
        };
        #endregion

        #region ShippingRequests
        public static ShippingRequest ShippingRequest1 { get; set; } = new ShippingRequest()
        {
            Id = "sid1",
            ShippingOptionId = 1,
            Status = Status.Packing,
            AddressFrom = new Address(),
            AddressTo = new Address(),
            BillingId = "bid1",
            DateOfDispatch = DateTime.Now,
            IsExpress = false,
            UserId = "teszt1",
            IsFinished = false,
            PaymentOptionId = 1,
            Name = "Teszt Elek",
            Packages = new List<Package>() { Package1, Package2 },
            Email = "teszt@teszt.hu",
            ShippingOption = ShippingOption1,
            PaymentOption = PaymentOption1,
            Billing = Billing1,
            CourierId = "cur1",
        };
        public static ShippingRequest ShippingRequest2 { get; set; } = new ShippingRequest()
        {
            Id = "sid2",
            ShippingOptionId = 2,
            Status = Status.Delivered,
            AddressFrom = new Address(),
            AddressTo = new Address(),
            BillingId = "bid2",
            DateOfDispatch = DateTime.Now,
            IsExpress = true,
            UserId = "teszt2",
            IsFinished = true,
            PaymentOptionId = 2,
            Name = "Teszt2 Elek",
            Packages = new List<Package>() { Package3, Package4 },
            Email = "teszt2@teszt.hu",
            ShippingOption = ShippingOption2,
            PaymentOption = PaymentOption2,
            Billing = Billing2,
            CourierId = "cur2",
        };
        #endregion
    }
}
