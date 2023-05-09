using System;
using System.Collections.Generic;

namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the Guarantee table in the database 
    /// </summary>
	public partial class Guarantee : Entity
	{
		#region Fields
		
		private long _iD;
		private int _guaranteeTypeID;
		private string _traderNTN;
		private int _traderRoleID;
		private int _traderSubscriptionID;
		private int? _agentSubscriptionID;
		private string _agentNTN;
		private int? _agentRoleID;
		private string _agentParentCollectorateCode;
		private string _guaranteeNumber;
        private decimal _totalAmount;
		private string _currencyCode;
        private DateTime _issueDate;
        private DateTime _expiryDate;
		private string _bankCode;
        private decimal _balanceAmount;
		private string _referenceNumber;
		private int _guaranteeStatusID;
		private bool _softDelete;
        private DateTime _createdOn;
        private int _createdBy;
        private DateTime _updatedOn;
        private int _updatedBy;

		#endregion

		#region Properties
		
		public long ID { get { return _iD; } set { _iD = value; PrimaryKey = value; }}
		public int GuaranteeTypeID { get { return _guaranteeTypeID; } set { _guaranteeTypeID = value;  }}
		public string TraderNTN { get { return _traderNTN; } set { _traderNTN = value;  }}
		public int TraderRoleID { get { return _traderRoleID; } set { _traderRoleID = value;  }}
		public int TraderSubscriptionID { get { return _traderSubscriptionID; } set { _traderSubscriptionID = value;  }}
		public int? AgentSubscriptionID { get { return _agentSubscriptionID; } set { _agentSubscriptionID = value;  }}
		public string AgentNTN { get { return _agentNTN; } set { _agentNTN = value;  }}
		public int? AgentRoleID { get { return _agentRoleID; } set { _agentRoleID = value;  }}
		public string AgentParentCollectorateCode { get { return _agentParentCollectorateCode; } set { _agentParentCollectorateCode = value;  }}
		public string GuaranteeNumber { get { return _guaranteeNumber; } set { _guaranteeNumber = value;  }}
		public decimal TotalAmount { get { return _totalAmount; } set { _totalAmount = value;  }}
		public string CurrencyCode { get { return _currencyCode; } set { _currencyCode = value;  }}
		public DateTime IssueDate { get { return _issueDate; } set { _issueDate = value;  }}
		public DateTime ExpiryDate { get { return _expiryDate; } set { _expiryDate = value;  }}
		public string BankCode { get { return _bankCode; } set { _bankCode = value;  }}
		public decimal BalanceAmount { get { return _balanceAmount; } set { _balanceAmount = value;  }}
		public string ReferenceNumber { get { return _referenceNumber; } set { _referenceNumber = value;  }}
		public int GuaranteeStatusID { get { return _guaranteeStatusID; } set { _guaranteeStatusID = value;  }}
        public bool SoftDelete { get { return _softDelete; } set { _softDelete = value; } }
		public DateTime CreatedOn { get { return _createdOn; } set { _createdOn = value; } }
        public int CreatedBy { get { return _createdBy; } set { _createdBy = value; } }
        public DateTime UpdatedOn { get { return _updatedOn; } set { _updatedOn = value; } }
        public int UpdatedBy { get { return _updatedBy; } set { _updatedBy = value; } }

		#endregion

		#region Methods

		#endregion

		#region public Methods

		public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object> 
			{
				{"ID", ID},
				{"GuaranteeTypeID", GuaranteeTypeID},
				{"TraderNTN", TraderNTN},
				{"TraderRoleID", TraderRoleID},
				{"TraderSubscriptionID", TraderSubscriptionID},
				{"AgentSubscriptionID", AgentSubscriptionID},
				{"AgentNTN", AgentNTN},
				{"AgentRoleID", AgentRoleID},
				{"AgentParentCollectorateCode", AgentParentCollectorateCode},
				{"GuaranteeNumber", GuaranteeNumber},
				{"TotalAmount", TotalAmount},
				{"CurrencyCode", CurrencyCode},
				{"IssueDate", IssueDate},
				{"ExpiryDate", ExpiryDate},
				{"BankCode", BankCode},
				{"BalanceAmount", BalanceAmount},
				{"ReferenceNumber", ReferenceNumber},
				{"GuaranteeStatusID", GuaranteeStatusID},
                {"SoftDelete", SoftDelete},
                {"CreatedOn", CreatedOn},
                {"CreatedBy", CreatedBy},
                {"UpdatedOn", UpdatedOn},
                {"UpdatedBy", UpdatedBy}
			};
        }

		public override object GetInsertUpdateParams()
        {
            return new
            {
				GuaranteeTypeID,
				TraderNTN,
				TraderRoleID,
				TraderSubscriptionID,
				AgentSubscriptionID,
				AgentNTN,
				AgentRoleID,
				AgentParentCollectorateCode,
				GuaranteeNumber,
				TotalAmount,
				CurrencyCode,
				IssueDate,
				ExpiryDate,
				BankCode,
				BalanceAmount,
				ReferenceNumber,
				GuaranteeStatusID,
                SoftDelete,
				CreatedOn,
				CreatedBy,
				UpdatedOn,
				UpdatedBy
			};
        }

		#endregion

		#region Constructors

		public Guarantee()
		{
			TableName = "Guarantee";
			PrimaryKeyName = "ID";
		}
		
		#endregion
	}
}