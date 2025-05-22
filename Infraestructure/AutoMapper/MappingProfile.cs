using AutoMapper;

namespace MakersApiWeb.Infraestructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Aquí se puede dejar vacío o usar para incluir manualmente los perfiles si no escaneas por ensamblado
            //AddProfile(new UserProfile());
            // AddProfile(new LoanProfile());
        }
    }
}
