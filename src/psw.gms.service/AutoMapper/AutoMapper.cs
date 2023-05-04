using AutoMapper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Service.DTO;


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
                    cfg.CreateMap<Guarantee, GetGuaranteeResponseDTO>();
                    cfg.CreateMap<UpdateGuaranteeTransactionRequestDTO, GuaranteeTransactionHistory>();
                    cfg.CreateMap<GuaranteeTransactionHistory, UpdateGuaranteeTransactionResponseDTO>();
                    cfg.CreateMap<GuaranteeTransactionHistory, GetGuaranteeHistoryResponseDTO>();
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
