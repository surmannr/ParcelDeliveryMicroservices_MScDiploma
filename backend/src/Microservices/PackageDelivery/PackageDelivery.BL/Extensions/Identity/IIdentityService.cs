using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Extensions.Identity
{
    public interface IIdentityService
    {
        string GetCurrentUserId();
    }
}
