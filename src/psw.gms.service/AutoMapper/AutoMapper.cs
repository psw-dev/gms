using AutoMapper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Service.DTO;
// using PSW.GMS.Service.DTO.CustomsRegistration.GetCustomsRegistrationList;


namespace PSW.GMS.Service.Mapper
{

    public class ObjectMapper
    {
        public IMapper _mapper { get; set; }

        public ObjectMapper()
        {
            ConfigureMappings();
        }

        public IMapper GetMapper()
        {
            return _mapper;
        }

        public void ConfigureMappings()
        {
            try
            {
                // Place All Mappings Here
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SaveGuaranteeDocumentRequestDTO, Guarantee>();
                    cfg.CreateMap<Guarantee, SaveGuaranteeDocumentResponseDTO>();
                });
                _mapper = config.CreateMapper();
            }
            catch
            {
                throw;
            }
        }

    }
}
