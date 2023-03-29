using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PSW.GMS.Service.DTO
{
    public class ActivityLogResponseDTO
    {
        [JsonPropertyName("sd")]
        public string SD { get; set; }

        [JsonPropertyName("gd")]
        public string GD { get; set; }

        [JsonPropertyName("gdStatus")]
        public string GDStatus { get; set; }

        [JsonPropertyName("documentClassificationCode")]
        public string DocumentClassificationCode { get; set; }

        [JsonPropertyName("requestDocumentNumber")]
        public string RequestDocumentNumber { get; set; }

        [JsonPropertyName("agencyName")]
        public string AgencyName { get; set; }

        [JsonPropertyName("agencySiteName")]
        public string AgencySiteName { get; set; }

        [JsonPropertyName("currentlyAssignedName")]
        public string CurrentlyAssignedName { get; set; }

        [JsonPropertyName("currentDocumentStatus")]
        public string CurrentDocumentStatus { get; set; }

        // [JsonPropertyName("currentlyAssignedUserName")]
        // public string CurrentlyAssignedUserName { get; set; }

        [JsonPropertyName("currentlyAssignedRole")]
        public string CurrentlyAssignedRole { get; set; }

        [JsonPropertyName("activityLog")]
        public List<ActivityLog> ActivityLogs { get; set; }
    }

    public class ActivityLog
    {

        [JsonPropertyName("name")]
        public string Name { get; set; }

        // [JsonPropertyName("userName")]
        // public string UserName { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("module")]
        public string Module { get; set; }

        [JsonPropertyName("activityName")]
        public string ActivityName { get; set; }

        [JsonPropertyName("activityDescription")]
        public string ActivityDescription { get; set; }

        [JsonPropertyName("actionDate")]
        public DateTime ActionDate { get; set; }

        [JsonPropertyName("isAgeComputable")]
        public bool IsAgeComputable { get; set; }
    }
}
