/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;
using System.Linq;


namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the IRMSEnabledDocumentType table in the database 
    /// </summary>
	public class IRMSEnabledDocumentType : Entity
	{
		#region Fields
		
		private int _iD;
		private string _documentTypeCode;
		private DateTime _effectiveFromDt;
		private DateTime _effectiveThruDt;
		private DateTime _createdOn;
		private int _createdBy;
		private DateTime _updatedOn;
		private int _updatedBy;

		#endregion

		#region Properties
		
		public int ID { get { return _iD; } set { _iD = value; PrimaryKey = value; }}
		public string DocumentTypeCode { get { return _documentTypeCode; } set { _documentTypeCode = value;  }}
		public DateTime EffectiveFromDt { get { return _effectiveFromDt; } set { _effectiveFromDt = value;  }}
		public DateTime EffectiveThruDt { get { return _effectiveThruDt; } set { _effectiveThruDt = value;  }}
		public DateTime CreatedOn { get { return _createdOn; } set { _createdOn = value;  }}
		public int CreatedBy { get { return _createdBy; } set { _createdBy = value;  }}
		public DateTime UpdatedOn { get { return _updatedOn; } set { _updatedOn = value;  }}
		public int UpdatedBy { get { return _updatedBy; } set { _updatedBy = value;  }}

		#endregion

		#region Methods

		#endregion

		#region public Methods

		public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object> 
			{
				{"ID", ID},
				{"DocumentTypeCode", DocumentTypeCode},
				{"EffectiveFromDt", EffectiveFromDt},
				{"EffectiveThruDt", EffectiveThruDt},
				{"CreatedOn", CreatedOn},
				{"CreatedBy", CreatedBy},
				{"UpdatedOn", UpdatedOn},
				{"UpdatedBy", UpdatedBy},
			};
        }

		#endregion

		#region Constructors

		public IRMSEnabledDocumentType()
		{
			TableName = "IRMSEnabledDocumentType";
			PrimaryKeyName = "ID";
		}
		
		#endregion
	}
} 

