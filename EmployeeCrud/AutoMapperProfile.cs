using AutoMapper;
using EmployeeCrud.Data.Models;
using EmployeeCrud.ViewModel;

namespace EmployeeCrud;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Department, DepartmentViewModel>().ReverseMap();
        CreateMap<Department, DepartmentDropDownViewModel>();

        CreateMap<Employee, EmployeeViewModel>()
            .ForMember(e => e.DepartmentName, opt => opt.MapFrom(e => e.DepartmentRef.Name))
            .ReverseMap()
            .ForPath(e => e.DepartmentRef.Name, opt => opt.Ignore());
    }
}