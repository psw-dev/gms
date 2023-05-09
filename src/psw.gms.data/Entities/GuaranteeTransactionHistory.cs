using System;
using System.Collections.Generic;

namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the GuaranteeTransactionHistory table in the database 
    /// </summary>
	public partial class GuaranteeTransactionHistory : Entity
	{
		#region Fields
		
		private long _iD;
		private long _guaranteeID;
		private long _attachedToDocumentID;
		private string _attachedToDocumentNumber;
		private string _attachedToDocumentTypeCode;
        private decimal? _consumedAmount;
		private int _guaranteeTransactionStatusID;
        private DateTime? _approvedOn;
        private DateTime? _rejectedOn;
		private bool _softDelete;
        private DateTime _createdOn;
        private int _createdBy;
        private DateTime _updatedOn;
        private int _updatedBy;

		#endregion

		#region Properties
		
		public long ID { get { return _iD; } set { _iD = value; PrimaryKey = value; }}
		public long GuaranteeID { get { return _guaranteeID; } set { _guaranteeID = value;  }}
		public long AttachedToDocumentID { get { return _attachedToDocumentID; } set { _attachedToDocumentID = value;  }}
		public string AttachedToDocumentNumber { get { return _attachedToDocumentNumber; } set { _attachedToDocumentNumber = value;  }}
		public string AttachedToDocumentTypeCode { get { return _attachedToDocumentTypeCode; } set { _attachedToDocumentTypeCode = value;  }}
		public decimal? ConsumedAmount { get { return _consumedAmount; } set { _consumedAmount = value;  }}
		public int GuaranteeTransactionStatusID { get { return _guaranteeTransactionStatusID; } set { _guaranteeTransactionStatusID = value;  }}
		public DateTime? ApprovedOn { get { return _approvedOn; } set { _approvedOn = value;  }}
		public DateTime? RejectedOn { get { return _rejectedOn; } set { _rejectedOn = value;  }}
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
				{"GuaranteeID", GuaranteeID},
				{"AttachedToDocumentID", AttachedToDocumentID},
				{"AttachedToDocumentNumber", AttachedToDocumentNumber},
				{"AttachedToDocumentTypeCode", AttachedToDocumentTypeCode},
				{"ConsumedAmount", ConsumedAmount},
				{"GuaranteeTransactionStatusID", GuaranteeTransactionStatusID},
				{"ApprovedOn", ApprovedOn},
				{"RejectedOn", RejectedOn},
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
				GuaranteeID,
                AttachedToDocumentID,
                AttachedToDocumentNumber,
                AttachedToDocumentTypeCode,
                ConsumedAmount,
                GuaranteeTransactionStatusID,
                ApprovedOn,
                RejectedOn,
                SoftDelete,
				CreatedOn,
				CreatedBy,
				UpdatedOn,
				UpdatedBy
			};
        }

		#endregion

		#region Constructors

		public GuaranteeTransactionHistory()
		{
			TableName = "GuaranteeTransactionHistory";
			PrimaryKeyName = "ID";
		}
		
		#endregion
	}
}