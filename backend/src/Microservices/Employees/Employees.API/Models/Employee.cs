// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using Common.Entity;
using Microsoft.AspNetCore.Identity;
using TypeGen.Core.TypeAnnotations;

namespace Employees.API.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    [TsIgnoreBase]
    public class Employee : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NamePrefix { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }

        public ICollection<Timesheet> Timesheets { get; set; }
    }
}