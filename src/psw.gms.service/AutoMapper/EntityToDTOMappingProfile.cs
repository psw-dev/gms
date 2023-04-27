using System.Collections.Generic;
using AutoMapper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Service.DTO;
using PSW.GMS.Common;
using PSW.GMS.Common.Constants;
using PSW.GMS.Common.Enums;
using System.Globalization;

namespace PSW.GMS.Service.AutoMapper
{
    public class EntityToDTOMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "EntityToDTOMappings"; }
        }
        public EntityToDTOMappingProfile()
        {
            var dateFormat = Utility.GetDateFormat();

            // CreateMap<CountryWithDialingCodes, GetAllCountryDialingCodesResponseDTO>()
            //                 .ForMember(dest => dest.CountryDialingCode, opt => opt.MapFrom(src => src.Name + " (" + src.DialCode + ")"));

            CreateMap<Guarantee, SaveGuaranteeDocumentResponseDTO>();
            // CreateMap<GuaranteeTransactionHistory, SaveGuaranteeDocumentResponseDTO>();
        }
    }
}