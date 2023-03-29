using System;
using System.Collections.Generic;
using System.Linq;
using PSW.GMS.Data.Entities;

namespace PSW.GMS.Data.Objects.Views

{
    public class UVImportPermitDetails : Entity
    {

        #region Fields

        // AS 
        private string _traderName;
        private string _agentName;
        private DateTime _date;
        private long _importPermitID;
        private string _commodityName;
        private string _status;

        // Country Fields 
        private string _consignorCityName;
        private string _consignorCountryName;
        private string _importFromCountryName;
        private string _originCountryName;


        // ImportPermit Table 


        private short _agencyID;
        private string _requestDocumentTypeCode;
        private string _requestDocumentNumber;
        private string _certDocumentTypeCode;
        private string _certDocumentNumber;
        private DateTime? _certIssueDate;
        private DateTime? _certEffectiveDate;
        private DateTime? _certExpiryDate;
        private DateTime? _certCancellationDate;
        private int _consigneeSubscriptionID;
        private int _consigneeUserRoleId;
        private int? _agentSubscriptionID;
        private string _agentChalNumber;
        private string _nTN;
        private string _applicantName;
        private string _applicantAddressFull;
        private string _applNumStreetPOBox;
        private string _applCountryCode;
        private short? _applCountryID;
        private string _applCountrySubEntityCode;
        private int? _applCityID;
        private string _applPostalCode;
        private string _consigneeName;
        private long? _organizationID;
        private long _consigneeAddressID;
        private string _consigneeAddressFull;
        private string _consigneePhoneNum;
        private string _consigneeCellNum;
        private string _consigneeFaxNum;
        private string _consigneeEmail;
        private string _consignorName;
        private string _consignorAddressFull;
        private string _consignorNumStreetPOBox;
        private string _consignorCountryCode;
        private short? _consignorCountryID;
        private string _consignorCountrySubEntityCode;
        private int? _consignorCityID;
        private string _consignorPostalCode;
        private string _consignorEmail;
        private string _consignorCellNum;
        private string _importFromCountryCode;
        private short? _importFromCountryID;
        private int _destCityID;
        private string _destCityName;
        private System.SByte _transportMeansID;
        private string _transportMeansName;
        private int _entryPortID;
        private string _entryPortName;
        private long? _billID;
        private decimal? _billAmount;
        private bool _isBillPaid;
        private int? _iRMSChannelID;
        private DateTime _importPemitCreatedOn;
        private int _importPemitCreatedBy;
        private DateTime? _submittedOn;
        private int? _submittedBy;
        private DateTime _importPemitUpdatedOn;
        private int _importPemitUpdatedBy;
        private DateTime? _approvedOn;
        private int? _approvedBy;
        private DateTime? _rejectedOn;
        private int? _rejectedBy;
        private short _impPermStatusID;
        private int? _assignedTo;
        private DateTime? _assignedOn;
        private int? _agencySiteLocationID;
        private int? _agencySiteID;
        private string _agencySiteName;

        // private System.Byte[] _lastChange;

        // ImportPermitItem Table 
        private long _importPermitItemID;
        private int _tradePurposeID;
        private string _tradePurposeName;
        private string _hSCode;
        private string _itemDescription;
        private string _otherDescription;
        private string _hSCodeExt;
        private string _itemDescriptionExt;
        private string _originCountryCode;
        private short? _originCountryID;
        private System.SByte _uoMID;
        private string _uoMName;
        private decimal _quantityDeclared;
        private decimal _quantityAllowed;
        private decimal _quantityConsumed;
        private decimal _noOfConsignments;
        private int _packageTypeId;
        private string _packageType;
        private decimal _packageCount;
        private string _technicalName;
        private string _portOfDischarge;
        private string _portOfEntry;
        private int? _meansOfTransportationID;
        private string _meansOfTransportationName;
        private DateTime _arrivalDate;
        private DateTime _importPermitItemCreatedOn;
        private int _importPermitItemCreatedBy;
        private DateTime _importPermitItemUpdatedOn;
        private int _importPermitItemUpdatedBy;
        private decimal _balanceQuantity;
        // private System.Byte[] _lastChange;

        // ImportPermitStatus Table
        private short _importPermitStatusID;
        private string _importPermitStatusName;
        // private short _agencyID;
        private short _consignmentCountAllowed;
        private string _referrerComments;
        private string _comments;
        private string _billDocumentNumber;
        private string _age;
        private int _importConditionID;
        private string _importConditionTitle;
        private string _importCondition;
        private string _declarationText;
        private byte _activeStepNo;
        private bool _isRevoked;
        private string _portTypeName;
        private int _agentUserRoleID;

        #endregion

        #region Properties


        // AS 
        public string TraderName { get { return _traderName; } set { _traderName = value; } }
        public string AgentName { get { return _agentName; } set { _agentName = value; } }
        public DateTime Date { get { return _date; } set { _date = value; } }
        public string CommodityName { get { return _commodityName; } set { _commodityName = value; } }

        public string Status { get { return _status; } set { _status = value; } }

        // Import Permit Table 
        public long ImportPermitID { get { return _importPermitID; } set { _importPermitID = value; PrimaryKey = value; } }
        public short AgencyID { get { return _agencyID; } set { _agencyID = value; } }
        public string RequestDocumentTypeCode { get { return _requestDocumentTypeCode; } set { _requestDocumentTypeCode = value; } }
        public string RequestDocumentNumber { get { return _requestDocumentNumber; } set { _requestDocumentNumber = value; } }
        public string CertDocumentTypeCode { get { return _certDocumentTypeCode; } set { _certDocumentTypeCode = value; } }
        public string CertDocumentNumber { get { return _certDocumentNumber; } set { _certDocumentNumber = value; } }
        public DateTime? CertIssueDate { get { return _certIssueDate; } set { _certIssueDate = value; } }
        public DateTime? CertEffectiveDate { get { return _certEffectiveDate; } set { _certEffectiveDate = value; } }
        public DateTime? CertExpiryDate { get { return _certExpiryDate; } set { _certExpiryDate = value; } }
        public DateTime? CertCancellationDate { get { return _certCancellationDate; } set { _certCancellationDate = value; } }
        public int ConsigneeSubscriptionID { get { return _consigneeSubscriptionID; } set { _consigneeSubscriptionID = value; } }
        public int ConsigneeUserRoleId { get { return _consigneeUserRoleId; } set { _consigneeUserRoleId = value; } }
        public int? AgentSubscriptionID { get { return _agentSubscriptionID; } set { _agentSubscriptionID = value; } }
        public string AgentChalNumber { get { return _agentChalNumber; } set { _agentChalNumber = value; } }
        public string NTN { get { return _nTN; } set { _nTN = value; } }
        public string ApplicantName { get { return _applicantName; } set { _applicantName = value; } }
        public string ApplicantAddressFull { get { return _applicantAddressFull; } set { _applicantAddressFull = value; } }
        public string ApplNumStreetPOBox { get { return _applNumStreetPOBox; } set { _applNumStreetPOBox = value; } }
        public string ApplCountryCode { get { return _applCountryCode; } set { _applCountryCode = value; } }
        public short? ApplCountryID { get { return _applCountryID; } set { _applCountryID = value; } }
        public string ApplCountrySubEntityCode { get { return _applCountrySubEntityCode; } set { _applCountrySubEntityCode = value; } }
        public int? ApplCityID { get { return _applCityID; } set { _applCityID = value; } }
        public string ApplPostalCode { get { return _applPostalCode; } set { _applPostalCode = value; } }
        public string ConsigneeName { get { return _consigneeName; } set { _consigneeName = value; } }
        public long? OrganizationID { get { return _organizationID; } set { _organizationID = value; } }
        public long ConsigneeAddressID { get { return _consigneeAddressID; } set { _consigneeAddressID = value; } }
        public string ConsigneeAddressFull { get { return _consigneeAddressFull; } set { _consigneeAddressFull = value; } }
        public string ConsigneePhoneNum { get { return _consigneePhoneNum; } set { _consigneePhoneNum = value; } }
        public string ConsigneeCellNum { get { return _consigneeCellNum; } set { _consigneeCellNum = value; } }
        public string ConsigneeFaxNum { get { return _consigneeFaxNum; } set { _consigneeFaxNum = value; } }
        public string ConsigneeEmail { get { return _consigneeEmail; } set { _consigneeEmail = value; } }
        public string ConsignorName { get { return _consignorName; } set { _consignorName = value; } }
        public string ConsignorAddressFull { get { return _consignorAddressFull; } set { _consignorAddressFull = value; } }
        public string ConsignorNumStreetPOBox { get { return _consignorNumStreetPOBox; } set { _consignorNumStreetPOBox = value; } }
        public string ConsignorCountryCode { get { return _consignorCountryCode; } set { _consignorCountryCode = value; } }
        public short? ConsignorCountryID { get { return _consignorCountryID; } set { _consignorCountryID = value; } }
        public string ConsignorCountrySubEntityCode { get { return _consignorCountrySubEntityCode; } set { _consignorCountrySubEntityCode = value; } }
        public int? ConsignorCityID { get { return _consignorCityID; } set { _consignorCityID = value; } }
        public string ConsignorPostalCode { get { return _consignorPostalCode; } set { _consignorPostalCode = value; } }
        public string ConsignorEmail { get { return _consignorEmail; } set { _consignorEmail = value; } }
        public string ConsignorCellNum { get { return _consignorCellNum; } set { _consignorCellNum = value; } }
        public string ImportFromCountryCode { get { return _importFromCountryCode; } set { _importFromCountryCode = value; } }
        public short? ImportFromCountryID { get { return _importFromCountryID; } set { _importFromCountryID = value; } }
        public int DestCityID { get { return _destCityID; } set { _destCityID = value; } }
        public string DestCityName { get { return _destCityName; } set { _destCityName = value; } }
        public System.SByte TransportMeansID { get { return _transportMeansID; } set { _transportMeansID = value; } }
        public string TransportMeansName { get { return _transportMeansName; } set { _transportMeansName = value; } }
        public int EntryPortID { get { return _entryPortID; } set { _entryPortID = value; } }
        public string EntryPortName { get { return _entryPortName; } set { _entryPortName = value; } }
        public long? BillID { get { return _billID; } set { _billID = value; } }
        public decimal? BillAmount { get { return _billAmount; } set { _billAmount = value; } }
        public bool IsBillPaid { get { return _isBillPaid; } set { _isBillPaid = value; } }
        public int? IRMSChannelID { get { return _iRMSChannelID; } set { _iRMSChannelID = value; } }
        public DateTime ImportPemitCreatedOn { get { return _importPemitCreatedOn; } set { _importPemitCreatedOn = value; } }
        public int ImportPemitCreatedBy { get { return _importPemitCreatedBy; } set { _importPemitCreatedBy = value; } }
        public DateTime? SubmittedOn { get { return _submittedOn; } set { _submittedOn = value; } }
        public int? SubmittedBy { get { return _submittedBy; } set { _submittedBy = value; } }
        public DateTime ImportPemitUpdatedOn { get { return _importPemitUpdatedOn; } set { _importPemitUpdatedOn = value; } }
        public int ImportPemitUpdatedBy { get { return _importPemitUpdatedBy; } set { _importPemitUpdatedBy = value; } }
        public DateTime? ApprovedOn { get { return _approvedOn; } set { _approvedOn = value; } }
        public int? ApprovedBy { get { return _approvedBy; } set { _approvedBy = value; } }
        public DateTime? RejectedOn { get { return _rejectedOn; } set { _rejectedOn = value; } }
        public int? RejectedBy { get { return _rejectedBy; } set { _rejectedBy = value; } }
        public short ImpPermStatusID { get { return _impPermStatusID; } set { _impPermStatusID = value; } }
        public int? AssignedTo { get { return _assignedTo; } set { _assignedTo = value; } }
        public DateTime? AssignedOn { get { return _assignedOn; } set { _assignedOn = value; } }
        public bool IsRevoked { get { return _isRevoked; } set { _isRevoked = value; } }
        public int? AgencySiteID { get { return _agencySiteID; } set { _agencySiteID = value; } }
        public int? AgencySiteLocationID { get { return _agencySiteLocationID; } set { _agencySiteLocationID = value; } }
        public string AgencySiteName { get { return _agencySiteName; } set { _agencySiteName = value; } }

        // public System.Byte[] LastChange { get { return _lastChange; } set { _lastChange = value;  }}

        // ImportPermitItem Table 
        public long ImportPermitItemID { get { return _importPermitItemID; } set { _importPermitItemID = value; PrimaryKey = value; } }
        public int TradePurposeID { get { return _tradePurposeID; } set { _tradePurposeID = value; } }
        public string TradePurposeName { get { return _tradePurposeName; } set { _tradePurposeName = value; } }
        public string HSCode { get { return _hSCode; } set { _hSCode = value; } }
        public string ItemDescription { get { return _itemDescription; } set { _itemDescription = value; } }
        public string OtherDescription { get { return _otherDescription; } set { _otherDescription = value; } }
        public string HSCodeExt { get { return _hSCodeExt; } set { _hSCodeExt = value; } }
        public string ItemDescriptionExt { get { return _itemDescriptionExt; } set { _itemDescriptionExt = value; } }
        public string OriginCountryCode { get { return _originCountryCode; } set { _originCountryCode = value; } }
        public short? OriginCountryID { get { return _originCountryID; } set { _originCountryID = value; } }
        public System.SByte UoMID { get { return _uoMID; } set { _uoMID = value; } }
        public string UoMName { get { return _uoMName; } set { _uoMName = value; } }
        public decimal QuantityDeclared { get { return _quantityDeclared; } set { _quantityDeclared = value; } }
        public decimal QuantityAllowed { get { return _quantityAllowed; } set { _quantityAllowed = value; } }
        public decimal QuantityConsumed { get { return _quantityConsumed; } set { _quantityConsumed = value; } }
        public decimal NoOfConsignments { get { return _noOfConsignments; } set { _noOfConsignments = value; } }
        public int PackageTypeId { get { return _packageTypeId; } set { _packageTypeId = value; } }
        public string PackageType { get { return _packageType; } set { _packageType = value; } }
        public decimal PackageCount { get { return _packageCount; } set { _packageCount = value; } }
        public string TechnicalName { get { return _technicalName; } set { _technicalName = value; } }
        public DateTime ArrivalDate { get { return _arrivalDate; } set { _arrivalDate = value; } }
        public DateTime ImportPermitItemCreatedOn { get { return _importPermitItemCreatedOn; } set { _importPermitItemCreatedOn = value; } }
        public int ImportPermitItemCreatedBy { get { return _importPermitItemCreatedBy; } set { _importPermitItemCreatedBy = value; } }
        public DateTime ImportPermitItemUpdatedOn { get { return _importPermitItemUpdatedOn; } set { _importPermitItemUpdatedOn = value; } }
        public int ImportPermitItemUpdatedBy { get { return _importPermitItemUpdatedBy; } set { _importPermitItemUpdatedBy = value; } }
        public string PortOfDischarge { get { return _portOfDischarge; } set { _portOfDischarge = value; } }
        public string PortOfEntry { get { return _portOfEntry; } set { _portOfEntry = value; } }
        public int? MeansOfTransportationID { get { return _meansOfTransportationID; } set { _meansOfTransportationID = value; } }
        public string MeansOfTransportationName { get { return _meansOfTransportationName; } set { _meansOfTransportationName = value; } }
        public decimal BalanceQuantity { get { return _balanceQuantity; } set { _balanceQuantity = value; } }

        // ImportPermitStatus Table 

        public short ImportPermitStatusID { get { return _importPermitStatusID; } set { _importPermitStatusID = value; PrimaryKey = value; } }
        public string ImportPermitStatusName { get { return _importPermitStatusName; } set { _importPermitStatusName = value; } }
        public short ConsignmentCountAllowed { get { return _consignmentCountAllowed; } set { _consignmentCountAllowed = value; } }
        public string ConsignorCityName { get { return _consignorCityName; } set { _consignorCityName = value; } }
        public string ConsignorCountryName { get { return _consignorCountryName; } set { _consignorCountryName = value; } }
        public string ImportFromCountryName { get { return _importFromCountryName; } set { _importFromCountryName = value; } }
        public string OriginCountryName { get { return _originCountryName; } set { _originCountryName = value; } }
        public string ReferrerComments { get { return _referrerComments; } set { _referrerComments = value; } }
        public string Comments { get { return _comments; } set { _comments = value; } }
        public string BillDocumentNumber { get { return _billDocumentNumber; } set { _billDocumentNumber = value; } }
        public string Age { get { return _age; } set { _age = value; } }
        public int ImportConditionID { get { return _importConditionID; } set { _importConditionID = value; } }
        public string ImportConditionTitle { get { return _importConditionTitle; } set { _importConditionTitle = value; } }
        public string ImportCondition { get { return _importCondition; } set { _importCondition = value; } }
        public byte ActiveStepNo { get { return _activeStepNo; } set { _activeStepNo = value; } }
        public string DeclarationText { get { return _declarationText; } set { _declarationText = value; } }
        public string PortTypeName { get { return _portTypeName; } set { _portTypeName = value; } }
        public int AgentUserRoleID { get => _agentUserRoleID; set => _agentUserRoleID = value; }

        #endregion

        #region Methods

        #endregion

        #region public Methods

        public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object>
            {
                // AS 

				{"TraderName", TraderName},
                {"AgentName", AgentName},
                {"Date", Date},
                {"HSCode", HSCode},
                {"CommodityName", CommodityName},
                {"Status", Status},

                {"ConsignorCityName", ConsignorCityName},
                {"ConsignorCountryName", ConsignorCountryName},
                {"ImportFromCountryName", ImportFromCountryName},
                {"OriginCountryName", OriginCountryName},


                 // Import Permit Table 
				{"ImportPermitID", ImportPermitID},
                {"AgencyID", AgencyID},
                {"RequestDocumentTypeCode", RequestDocumentTypeCode},
                {"RequestDocumentNumber", RequestDocumentNumber},
                {"CertDocumentTypeCode", CertDocumentTypeCode},
                {"CertDocumentNumber", CertDocumentNumber},
                {"CertIssueDate", CertIssueDate},
                {"CertEffectiveDate", CertEffectiveDate},
                {"CertExpiryDate", CertExpiryDate},
                {"CertCancellationDate", CertCancellationDate},
                {"ConsigneeSubscriptionID", ConsigneeSubscriptionID},
                {"ConsigneeUserRoleId", ConsigneeUserRoleId},
                {"AgentSubscriptionID", AgentSubscriptionID},
                {"AgentChalNumber", AgentChalNumber},
                {"NTN", NTN},
                {"ApplicantName", ApplicantName},
                {"ApplicantAddressFull", ApplicantAddressFull},
                {"ApplNumStreetPOBox", ApplNumStreetPOBox},
                {"ApplCountryCode", ApplCountryCode},
                {"ApplCountryID", ApplCountryID},
                {"ApplCountrySubEntityCode", ApplCountrySubEntityCode},
                {"ApplCityID", ApplCityID},
                {"ApplPostalCode", ApplPostalCode},
                {"OrganizationID", OrganizationID},
                {"ConsigneeName", ConsigneeName},
                {"ConsigneeAddressID", ConsigneeAddressID},
                {"ConsigneeAddressFull", ConsigneeAddressFull},
                {"ConsigneePhoneNum", ConsigneePhoneNum},
                {"ConsigneeCellNum", ConsigneeCellNum},
                {"ConsigneeFaxNum", ConsigneeFaxNum},
                {"ConsigneeEmail", ConsigneeEmail},
                {"ConsignorName", ConsignorName},
                {"ConsignorAddressFull", ConsignorAddressFull},
                {"ConsignorNumStreetPOBox", ConsignorNumStreetPOBox},
                {"ConsignorCountryCode", ConsignorCountryCode},
                {"ConsignorCountryID", ConsignorCountryID},
                {"ConsignorCountrySubEntityCode", ConsignorCountrySubEntityCode},
                {"ConsignorCityID", ConsignorCityID},
                {"ConsignorPostalCode", ConsignorPostalCode},
                {"ConsignorEmail", ConsignorEmail},
                {"ConsignorCellNum", ConsignorCellNum},
                {"ImportFromCountryCode", ImportFromCountryCode},
                {"ImportFromCountryID", ImportFromCountryID},
                {"DestCityID", DestCityID},
                {"DestCityName", DestCityName},
                {"TransportMeansID", TransportMeansID},
                {"TransportMeansName", TransportMeansName},
                {"BillID", BillID},
                {"BillAmount", BillAmount},
                {"IRMSChannelID", IRMSChannelID},
                {"ImportPemitCreatedOn", ImportPemitCreatedOn},
                {"ImportPemitCreatedBy", ImportPemitCreatedBy},
                {"SubmittedOn", SubmittedOn},
                {"SubmittedBy", SubmittedBy},
                {"ImportPemitUpdatedOn", ImportPemitUpdatedOn},
                {"ImportPemitUpdatedBy", ImportPemitUpdatedBy},
                {"ApprovedOn", ApprovedOn},
                {"ApprovedBy", ApprovedBy},
                {"RejectedOn", RejectedOn},
                {"RejectedBy", RejectedBy},
                {"ImpPermStatusID", ImpPermStatusID},
                {"AssignedTo", AssignedTo},
                {"AssignedOn", AssignedOn},
                {"ArrivalDate", ArrivalDate},
                {"IsRevoked", IsRevoked},
                {"AgencySiteLocationID", AgencySiteLocationID},
                {"AgencySiteID", AgencySiteID},
                {"AgencySiteName", AgencySiteName},
				//{"LastChange", LastChange}

                // ImportPermitItem
                {"ImportPermitItemID", ImportPermitItemID},
                {"ImportPermitID", ImportPermitID},
                {"TradePurposeID", TradePurposeID},
                {"TradePurposeName", TradePurposeName},

                {"ItemDescription", ItemDescription},
                {"OtherDescription", OtherDescription},
                {"HSCodeExt", HSCodeExt},
                {"ItemDescriptionExt", ItemDescriptionExt},
                {"OriginCountryCode", OriginCountryCode},
                {"OriginCountryID", OriginCountryID},
                {"UoMID", UoMID},
                {"UoMName", UoMName},
                {"QuantityDeclared", QuantityDeclared},
                {"QuantityAllowed", QuantityAllowed},
                {"QuantityConsumed", QuantityConsumed},
                {"NoOfConsignments", NoOfConsignments},
                {"PackageTypeId", PackageTypeId},
                {"PackageType", PackageType},
                {"PackageCount", PackageCount},
                {"TechnicalName", TechnicalName},
                {"ImportPermitItemCreatedOn", ImportPermitItemCreatedOn},
                {"CreatedBImportPermitItemCreatedBy", ImportPermitItemCreatedBy},
                {"ImportPermitItemUpdatedOn", ImportPermitItemUpdatedOn},
                {"ImportPermitItemUpdatedBy", ImportPermitItemUpdatedBy},
                   {"PortOfDischarge", PortOfDischarge},
                   {"PortOfEntry", PortOfEntry},
              {"MeansOfTransportationID", MeansOfTransportationID},
              {"MeansOfTransportationName", MeansOfTransportationName},
                {"BalanceQuantity",BalanceQuantity},

                // ImportPermitStatus Table

                {"ImportPermitStatusID", ImportPermitStatusID},
                {"ImportPermitStatusName", ImportPermitStatusName},
                {"ConsignmentCountAllowed", ConsignmentCountAllowed},
                {"ReferrerComments", ReferrerComments},
                {"Comments", Comments},
                {"BillDocumentNumber", BillDocumentNumber},
                {"IsBillPaid", IsBillPaid},
                {"Age", Age},
                {"ImportConditionID", ImportConditionID},
                {"ImportConditionTitle", ImportConditionTitle},
                {"ImportCondition", ImportCondition},
                {"ActiveStepNo", ActiveStepNo},
                {"DeclarationText", DeclarationText},
                {"PortTypeName",PortTypeName}
				// {"AgencyID", AgencyID}


			};
        }

        #endregion

        #region Constructors

        public UVImportPermitDetails()
        {
            TableName = "UVImportPermitDetails";
            PrimaryKeyName = "ImportPermitID";
        }

        #endregion
    }
}