namespace PSW.GMS.Common.Constants
{
    public static class Constant
    {
        public static string IRMSChannelAssignment = "1";
        public static string ActiveCountry = "ActiveCountry";
        public static string SendInboxMessageMethodId = "1330";
        public static string GenerateVoucherMethodId = "1416";
        public static string GetRequirementsMethodId = "1722";
        public static string GetFileDetails = "1214";
        public static string GetFilePath = "1215";
        public static string GetFileBytes = "1216";
        public static string AddSubscribedUserRole = "1276";
        public static string DeleteSubscribedUserRole = "1277";
        public static string MFDPremisePerFacilityRenewalFee = "MFDPremisePerFacilityRenewalFee";
        public static string MFDPremisePerFacilityPenalityRenewalFee = "MFDPremisePerFacilityPenalityRenewalFee";
        public static decimal DefaultMFDPremisePerFacilityRenewalFee = 10000;
        public static decimal DefaultMFDPremisePerFacilityPenalityRenewalFee = 10000;

        public static string MFDPremiseRegistrationPerFacilityFee = "MFDPremiseRegistrationPerFacilityFee";
        public static decimal DefaultPremiseRegistrationPerFacilityFee = 25000;

        public static string DPP_Form18_PremiseRegistrationFee = "DPPForm18PremiseRegistrationFee";
        public static decimal Default_DPP_Form18_PremiseRegistration = 500000;

        public static string DPP_Form19_PremiseRegistrationFee = "DPPForm19PremiseRegistrationFee";
        public static decimal Default_DPP_Form19_PremiseRegistration = 250000;

        public static string DPP_Form20_PremiseRegistrationFee = "DPPForm20PremiseRegistrationFee";
        public static decimal Default_DPP_Form20_PremiseRegistration = 500000;

        public static string DPP_Form18_PremiseRegistrationCertExpiryDate_In_Months = "DPPForm18PremiseRegistrationCertExpiryDate";
        public static int Default_DPP_Form18_PremiseRegistrationCertExpiryDate_In_Months = 60;

        public static string DPP_Form19_PremiseRegistrationCertExpiryDate_In_Months = "DPPForm19PremiseRegistrationCertExpiryDate";
        public static int Default_DPP_Form19_PremiseRegistrationCertExpiryDate_In_Months = 60;


        public static string DPP_Form20_PremiseRegistrationCertExpiryDate_In_Months = "DPPForm20PremiseRegistrationCertExpiryDate";
        public static int Default_DPP_Form20_PremiseRegistrationCertExpiryDate_In_Months = 60;


    }

    public static class AGENCY_CODES
    {
        public static string PSW = "PSW";
        public static string DPP = "DPP";
        public static string AQD = "AQD";
        public static string FSCRD = "FSCRD";
        public static string PSQ = "PSQ";
    }


    public static class REGISTRATION_URL
    {
        // public static string RENEWAL_VIEW = "/registration/premises/renewalView";
        // public static string AMENDMENT_VIEW = "/registration/premises/amendmentView";
        public static string REGISTRATION_VIEW = "/registration/premises/view";
    }

    public static class AllowedReviewCount
    {
        public static int MFD = 10;
    }

    public static class RegistrationTables
    {
        public static string PREMISEFACILITYITEM = "premisefacilityitem";
        public static string AGENCYPREMISEREGISTRATION = "agencypremiseregistration";
        public static string REGISTRATIONELEMENTDATAJSON = "registrationelementdatajson";
        public static string ATTACHMENT = "attachment";
        public static string AGENCYCOMMODITYREGISTRATION = "agencycommodityregistration";
        public static string AGENCYCOMMODITYREGISTRATIONHDR = "agencycommodityregistrationhdr";

    }

    public static class NotificationText
    {
        public static string PremisesRegistrationRequestText = "premises registration request";
        public static string PremisesRegistrationAmendmentRequestText = "premises registration amendment request";
        public static string PremisesRegistrationRenewalRequestText = "premises facility renewal request";
    }

    public static class UploadPremisesRegisteationErrorMsg
    {
        public static string INVALID_SITE = "CustomError.Site not found or not given";
        public static string MFD_SITE_NOT_IN_SYSTEM = "CustomError.Active Site not found in system for MFD";
        public static string MFD_CITY_NOT_IN_SYSTEM = "CustomError.Active City not found in system for MFD";
        public static string INVALID_CITY = "CustomError.City not found or not given";
        public static string INVALID_FIRM_STATUS = "CustomError.Invalid Status of Firm value given";
        public static string INVALID_DATE = "CustomError.Invalid Date format. Allow format is dd-MM-yyyy";
        public static string INVALID_NTN = "CustomError.Invalid NTN. It should be same with NTN that is registered against current logged in account";
    }

    public static class PremisesRegisteationAmendmentErrorMsg
    {
        public static string INVALID_FIELD_VALUE = "CustomError.Invalid value given in field : ";
        public static string INVALID_DATE = "CustomError.Invalid Date format. Allow format is dd-MM-yyyy";
    }

    public static class FieldControlTypesId
    {
        public static short COMBOBOX = 1;
        public static short TEXT = 2;
        public static short DATE = 3;
        public static short NUMERIC = 4;
        public static short TEXTAREA = 5;
        public static short CALENDER = 6;
        public static short DECIMAL = 7;
        public static short CHECKBOX = 8;
        public static short GRID = 9;
        public static short HEADING = 10;
        public static short GROUPCHECKBOX = 11;
        public static short ATTACHMENT = 12;
        public static short CURRENCY = 16;
        public static short HSCODECOMPONENT = 15;
        public static short RADIOGROUP = 14;
        public static short TEXTBOXGROUP = 17;
        public static short LABEL = 18;
    }
    public static class ExportCertificateReviewStatus
    {
        public static short PENDING = 1;
        public static short APPROVED = 2;
        public static short REJECTED = 3;
    }
    public static class FieldControlDataTypes
    {
        public static string COMBOBOX = "combobox";
        public static string TEXT = "string";
        public static string DATE = "datetime";
        public static string NUMERIC = "int";
        public static string TEXTAREA = "string";
        public static string CALENDER = "datetime";
        public static string DECIMAL = "decimal";
        public static string CHECKBOX = "checkbox";
        public static string GRID = "grid";
        public static string HEADING = "string";
        public static string GROUPCHECKBOX = "checkbox";
    }
    public enum FieldControlSectionTypes
    {
        PLANT_TYPE = 21

    }

    public struct DocumentInfo
    {
        public const string SINGLE_DECLARATION = "PS1";
        public const string DOC_TYPE_CODE = "904";
        public const string PHYSICAL_INSPECTION_CODE = "905";
        public const string CALL_LAB_CODE = "906";
        public const string IMPORT_PERMIT_CODE = "D11";
        public const string TARP_IMPORT_PERMIT_CODE = "D12";
        public const string IMPORT_PERMIT_AMENDMENT_CODE = "D56";
        public const string IMPORT_PERMIT_EXTENSION_CODE = "D57";
        public const string PSI_REPORT = "D58";
        public const string RELEASE_ORDER_CODE = "D04";
        public const string RELEASE_ORDER_CERTIFICATE_CODE = "D03";
        public const string EXPORT_CERTIFICATE_CODE = "D06";
        public const string EXPORT_CERTIFICATE_COMPLETED_CODE = "D15";
        public const string EXPORT_CERTIFICATE_AQD_EXTENSIN_CODE = "E02";
        public const string EXPORT_CERTIFICATE_MFD_EXTENSIN_CODE = "E03";
        public const string PHYSICAL_INSPECTION_FUMIGATION_REPORT = "M88";
        public const string RELEASE_ORDER_DOCUMENT_CLASSIFICATION_CODE = "RO";
        public const string EXPORT_CERTIFICATE_DOCUMENT_CLASSIFICATION_CODE = "EC";
        public const string CATCH_CERTIFICATE_DOCUMENT_CLASSIFICATION_CODE = "CC";
        public const string IMPORT_PERMIT_DOCUMENT_CLASSIFICATION_CODE = "IMP";
        public const string IMPORT_PERMIT_AMENDMENT_CLASSIFICATION_CODE = "IPA";
        public const string OGA_PAYMENT_MASTER_CLASSIFICATION_CODE = "OPM";
        public const int DOC_FORMAT = 2; //Native Electronic Document
        public const int ATTACHED_DOC_FORMAT = 1; //Scanned Document
        public const string PSQCA_RELEASE_ORDER_CODE = "R01";
        public const string PSQCA_RELEASE_ORDER_REQUEST_CODE = "R02";
        public const string AQD_RELEASE_ORDER_CODE = "R07";
        public const string AQD_INTERIM_RELEASE_ORDER_CODE = "R09";
        public const string AMENDMENT_FOR_EXPORT_CERTIFICATE_CODE = "E01";
        public const string LAB_PAYMENT_CODE = "L01";
        public const string FSCRD_SEED_ENLISTMENT_HEADER_REQUEST = "SE1";
        public const string FSCRD_SEED_ENLISTMENT_REQUEST = "SE2";
        public const string FSCRD_SEED_BUSINESS_NATIONAL_REGISTER = "F27";
        public const string FSCRD_SEED_BUSINESS_NATIONAL_REGISTER_CERTIFICATE = "F28";
        public const string FSCRD_RELEASE_ORDER = "R05";
        public const string MFD_PREMISES_REGISTRATION_CODE = "A08";
        public const string MFD_PREMISES_REGISTRATION_REQUEST_CODE = "A09";

        public const string MFD_PREMISES_REGISTRATION_CERTIFICATE_CODE = "A11";

        public const string MFD_PREMISES_REGISTRATION_DOCUMENT_CLASSIFICATION_CODE = "PRM";
        public const string MFD_PREMISES_REGISTRATION_AMENDMENT = "A17";
        public const string EXPORT_CERTIFICATE_REVIEW = "R50";
        public const string MFD_PREMISES_REGISTRATION_RENEWAL = "A18";
        public const string DPP_FORM_18_PREMISES_REGISTRATION_REQUEST_CODE = "F30";
        public const string DPP_FORM_18_PREMISES_REGISTRATION_CERTIFICATE_CODE = "F29";
        public const string DPP_FORM_19_PREMISES_REGISTRATION_REQUEST_CODE = "F32";
        public const string DPP_FORM_19_PREMISES_REGISTRATION_CERTIFICATE_CODE = "F31";
        public const string DPP_FORM_20_PREMISES_REGISTRATION_REQUEST_CODE = "F34";
        public const string DPP_FORM_20_PREMISES_REGISTRATION_CERTIFICATE_CODE = "F33";
        public const string DPP_FORM_1_PRODUCT_REGISTRATION_REQUEST_CODE = "F19";
        public const string DPP_FORM_1_PRODUCT_REGISTRATION_CERTIFICATE_CODE = "F20";
        public const string DPP_FORM_16_PRODUCT_REGISTRATION_REQUEST_CODE = "F21";
        public const string DPP_FORM_16_PRODUCT_REGISTRATION_CERTIFICATE_CODE = "F22";
        public const string DPP_FORM_17_PRODUCT_REGISTRATION_REQUEST_CODE = "F23";
        public const string DPP_FORM_17_PRODUCT_REGISTRATION_CERTIFICATE_CODE = "F24";
        public const string EXPORT_PERMIT_REQUEST_CODE = "A22";
        public const string EXPORT_PERMIT_CERTIFICATE_CODE = "A23";

    }

    public enum IRMSChannel
    {
        Green,
        Yellow,
        Red,
    }

    public enum AttachmentStatusEnum
    {
        REQUESTED = 1,
        COMPLETED = 2

    }

    public enum FindingsAndTreatmentsStatusEnum
    {
        REQUESTED = 1
    }

    public struct AltCode
    {
        public const string CERTIFICATE = "C";
        public const string REQUEST = "R";
        public const string INTERIM = "I";
        public const string REVIEW = "RE";
    }

    public enum SearchByDppDashboard
    {
        YEAR = 0,
        MONTH = 1,
        WEEK = 2,
        DAY = 3,

    }

    // public struct AltCode
    // {
    //     public const string CERTIFICATE = "C";
    //     public const string REQUEST = "R";
    // }
    public enum TradeTranType
    {
        IMPORT = 1,
        EXPORT = 2,
        TRANSIT = 3
    }

    public static class DocumentClassificationCode
    {
        public const string CATCH_CERTIFICATE = "CC";
        public const string EXPORT_CERTIFICATE = "EC";
        public const string RELEASE_ORDER = "RO";
        public const string IMPORT_PERMIT = "IMP";
        public const string IMPORT_PERMIT_AMENDMENT = "IPA";
        public const string SINGLE_DECLARATION = "SD";
        public const string FSCRD_SEED_ENLISTMENT_DOCUMENT_CLASSIFICATION_CODE = "PRD";
        public const string HEALTH_CERTIFICATE = "HC";
        public const string CATCH_CERTIFICATE_REQUEST = "CC2";
        public const string MFD_EXPORT_CERTIFICATE_REQUEST = "A07";

        public const string PREMISE_REGISTRATION = "PRM";
        public const string EXPORT_PERMIT = "EXP";
        public const string PRODUCT_REGISTRATION = "PRR";

    }

    public static class FileContentTypes
    {
        public const string PDF = "application/pdf";
    }
    public static class LabPaymentStatus
    {
        public const string PAID = "Paid";
        public const string UNPAID = "UnPaid";
    }

    public struct DocumentRegistrationCode
    {
        public const string PRODUCT_OLD = "PRD";
        public const string PREMISES = "PRM";
        public const string BUSINESS = "BSS";
        public const string PRODUCT = "PRR";

    }

    public struct ReleaseOrderReviewStatus
    {
        public const int PENDING = 1;
        public const int COMPLETED = 2;
    }
    public static class DocumentNames
    {
        public const string EXPORT_CERTIFICATE = "Export Certificate";
        public const string RELEASE_ORDER = "Release Order";
        public const string IMPORT_PERMIT = "Import Permit";
    }
    public static class DateFormates
    {
        public const string DD_MM_YYYY = "dd/MM/yyyy";
    }
    public enum PremisesActionTypes
    {
        AMENDMENT = 1,
        REGISTRATION = 3,

        RENEWAL = 4
    }
    public enum PremisesAction
    {
        SUBMIT = 0,

        VIEW = 5,

        CREATE = 6,
        DRAFT = 2
    }
    public enum TransactionType
    {
        Credit = 1,
        Debit = 2
    }
    public struct ReplyCode
    {
        public const string OK = "200";
        public const string BadRequest = "400";
        public const string NotFound = "404";
        public const string InternalServerError = "500";
        public const string UnAuthorized = "401";
    }
    public struct DebitingMode
    {
        public const string Auto = "Auto";
        public const string Manual = "Manual";
    }
    public struct OfficerTitle
    {
        public const string MFDFisheryOfficer = "Fishery Officer";
    }

    public struct WeBOCResponseCode
    {
        public const long Succcess = 2001;
    }

    public struct ServiceMethod
    {
        // SD
        public const string SD_GET_RELEASE_ORDER_INFO = "1983";
        public const string SD_GET_IGM_INFO = "1915";
        public const string SD_GET_BLVIR_INFO = "1986";
        public const string SD_GET_EXPORT_CERTIFICATE_INFO = "1989";
        public const string SD_GET_IMPORTER_EXPORTER_INFO = "1981";
        public const string SD_VOUCHER_UPDATE = "19AA";
        public const string SD_GET_INFORMATION_BY_SDID = "19P1"; // Used for PSQCA
        public const string SD_GET_GD_INFORMATION_BY_SDID = "1923";
        public const string SD_GET_ATTACHED_IMPORT_PERMIT_BY_SDID = "194B";

        //UMS
        public const string UMS_GET_DOCUMENT_ASSIGNEE = "1257";
        public const string UMS_GET_DOCUMENT_ASSIGNEE_INFORMATION = "1260";
        public const string UMS_GET_ASSIGNED_USER_INFORMATION = "1264";

        public const string UMS_GET_ASSIGNED_USER_INFORMATIO_LIST = "1265";

        //CLM
        public const string CLM_UPDATE_OGA_STATUS = "9002";
        public const string CLM_UPDATE_REJECTED_OGA_CLEARANCE = "9007";

        //UPS
        public static string UPS_GENERATE_VOUCHER = "1416";

        //TARP
        public static string TARP_GET_FORM_NUMBER = "1730";

        //WFS
        public static string WFS_Create_Process_Instance = "1817";

        // LMS
        public static string SUBMIT_CALL_LAB = "9131";
        public static string CALL_LAB_HISTORY = "9138";
        public static string GET_SD_CONTAINERS = "19H8";

        //AUTH
        public const string AUTH_GET_TRADER_BASIC_INFORMATION = "1071";

        public static string GET_ATTACHED_DOCUMENT_IN_SD = "19M4";
        public static string GET_LAB_EC_Detail = "9150";


        //PSI
        public static string FETCH_PSI_REPORT = "29AK";
        public static string PSI_UPDATE_PAYMENT_STATUS = "29AM";
    }

    public static class IPCLogStatus
    {
        public const string Information = "I";
        public const string Failed = "F";
        public const string Success = "S";
    }
}