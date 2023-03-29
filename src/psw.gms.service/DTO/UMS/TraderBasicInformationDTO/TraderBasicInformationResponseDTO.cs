using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace PSW.GMS.Service.DTO
{
    public class TraderBasicInformationResponseDTO
    {
        [JsonPropertyName("agentNTN")]
        public string AgentNTN { get; set; }

        [JsonPropertyName("agentSubscriptionId")]
        public long AgentSubscriptionId { get; set; }

        [JsonPropertyName("agentChalNumber")]
        public string AgentChalNumber { get; set; }

        [JsonPropertyName("agentOrganizations")]
        public List<OrganizationDTO> Organizations { get; set; }

        [JsonPropertyName("organizationsOnNTNs")]
        public List<OrganizationsOnNTNDTO> OrganizationsOnNTN { get; set; }
    }

    public class OrganizationsOnNTNDTO
    {
        [JsonPropertyName("NTN")]
        public string NTN { get; set; }

        [JsonPropertyName("userRoleId")]
        public int UserRoleId { get; set; }

        [JsonPropertyName("importerConsigneeSubscriptionId")]
        public long SubscriptionId { get; set; }

        [JsonPropertyName("companyId")]
        public int CompanyId { get; set; }

        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("companyNameWithNTN")]
        public string CompanyNameWithNTN { get; set; }

        [JsonPropertyName("organizations")]
        public List<OrganizationDTO> Organizations { get; set; }
    }

    public class OrganizationDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("importerConsigneeName")]
        public string ImporterName { get; set; }

        [JsonPropertyName("importerConsigneeAddress")]
        public List<AddressDTO> ImporterAddress { get; set; }

        [JsonPropertyName("importerConsigneePhone")]
        public string Phone { get; set; }

        [JsonPropertyName("importerConsigneeEmail")]
        public string Email { get; set; }

        [JsonPropertyName("importerConsigneeCellNo")]
        public string CellNumber { get; set; }
    }

    public class AddressDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("importerConsigneeCountryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("importerConsigneeCountryId")]
        public short? CountryId { get; set; }

        [JsonPropertyName("importerConsigneeCountrySubEntityCode")]
        public string CountrySubEntityCode { get; set; }

        [JsonPropertyName("importerConsigneeCityId")]
        public int? CityId { get; set; }

        [JsonPropertyName("importerConsigneePostalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("importerConsigneeNumStreetPOBox")]
        public string StreetPOBox { get; set; }
    }
}
