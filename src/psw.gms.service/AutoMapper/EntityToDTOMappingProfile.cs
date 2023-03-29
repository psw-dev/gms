using System.Collections.Generic;
using AutoMapper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Data.Objects.Views;
using PSW.GMS.Service.DTO;
using PSW.GMS.Common;
// using PSW.GMS.Service.DTO.EDI;
using PSW.GMS.Common.Constants;
// using PSW.GMS.Service.DTO;
using PSW.GMS.Common.Enums;
// using PSW.GMS.Service.DTO.WEBOC;
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
            // GetCityByCountryResponseDTO

            // GetAllCountryDialingCodesResponseDTO
            // CreateMap<CountryWithDialingCodes, GetAllCountryDialingCodesResponseDTO>()
            //                 .ForMember(dest => dest.CountryDialingCode, opt => opt.MapFrom(src => src.Name + " (" + src.DialCode + ")"));

            // CreateMap<City, CityDTO>();
            
            // CreateMap<StorageType, ListDTO>();

        }
    }
}