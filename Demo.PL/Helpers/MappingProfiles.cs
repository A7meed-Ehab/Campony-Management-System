using AutoMapper;
using Demo.DAL.Models;
using Demo.PL.Models;

namespace Demo.PL.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, CreateEmployeeViewModel>().ForMember(v => v.DepartmentName, d => d.MapFrom(m => m.Department.Name)).ReverseMap();
        }
    }
}
