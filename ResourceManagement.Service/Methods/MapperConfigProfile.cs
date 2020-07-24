using AutoMapper;
using ResourceManagement.DTO.Model;
using ResourceManagement.Models.Model;

namespace ResourceManagement.Service.Methods
{
    public class MapperConfigProfile : Profile
    {
        #region Constracutor

        public MapperConfigProfile()
        {
            
   
            CreateMap<FloorDTO, Floor>()
                .ReverseMap();

            CreateMap<EmployeeTypeDTO, EmployeeType>()
                .ReverseMap();

            CreateMap<SeatTypeDTO, SeatType>()
                .ReverseMap();

            CreateMap<UpdateSeatAllocationDTO, UpdateSeatAllocation>()
                .ReverseMap();

            CreateMap<EmployeeDTO, Employee>()
                .ReverseMap();

            CreateMap<EmployeeDetailDTO, Employee>().
                ReverseMap();
            
            CreateMap<SeatDetailDTO, SeatDetails>().
               ReverseMap();

            CreateMap<EmployeeSeatDetailDTO, EmployeeSeatDetail>().
                ReverseMap();

            CreateMap<AllEmployeeSeatDetailsDTO, EmpSeatDetails>().
                ReverseMap();

            CreateMap<SearchDTO, Search>().
                ReverseMap();

            CreateMap<SeatModel, SeatModelDTO>().ReverseMap();
        }

        #endregion
    }
}
