using AutoMapper;
using EmployeePlayGround.ViewModels;
using EmployeePlayGround.Core.Entities;

namespace EmployeePlayGround.Configuration
{
    internal class AutoMapperProfile : Profile
    {
        internal AutoMapperProfile()
        {
            CreateMap<EmployeeVm, Employee>();
        }
    }
}
