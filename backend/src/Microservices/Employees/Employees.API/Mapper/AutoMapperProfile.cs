using AutoMapper;
using Common.Entity;
using Employees.API.Models;
using EventBus.Messages.EventObjects;

namespace Employees.API.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeEO>().ReverseMap();
            CreateMap<Timesheet, TimesheetEO>().ReverseMap();
            CreateMap<Address, AddressEO>().ReverseMap();
        }
    }
}
