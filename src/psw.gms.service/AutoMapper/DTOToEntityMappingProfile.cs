using System;
using System.Globalization;
using AutoMapper;
// using PSW.GMS.Common.Helper;
using PSW.GMS.Data.Entities;
using PSW.GMS.Service.DTO;

namespace PSW.GMS.Service.AutoMapper
{
    public class DTOToEntityMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DTOToEntityMappings"; }
        }
        public DTOToEntityMappingProfile()
        {
            var _culture = new CultureInfo("en-Us");

            //GetCityByCountryRequestDTO
            // CreateMap<GetCityByCountryRequestDTO, Country>()
            //     .ForMember(dest => dest.Code , opt => opt.MapFrom(src => src.CountryCode));

            //GetImportPermitsResponseDTO


        }
    }
}