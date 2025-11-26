using AutoMapper;
using WebUF.ViewModel;


namespace WebUF.Profiles
{
    public class EstadoProfile : Profile
    {
        public EstadoProfile()
        {
            // Mapeamento entre EstadoModel e EstadoViewModel
            CreateMap<EstadoDto, EstadoViewModel>().ReverseMap();

        }
    }
}
