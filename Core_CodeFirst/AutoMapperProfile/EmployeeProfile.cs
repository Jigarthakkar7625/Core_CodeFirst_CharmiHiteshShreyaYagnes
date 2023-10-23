using AutoMapper;
using Core_CodeFirst.Data.Models;
using Core_CodeFirst.Models;

namespace Core_CodeFirst.AutoMapperProfile
{
    public class EmployeeProfile : Profile
    {

        public EmployeeProfile()
        {
            // Outgoing
            CreateMap<EmployeeDTO, Employee>();

            // Incoming
            CreateMap<Employee, EmployeeDTO>();

        }
    }
}
