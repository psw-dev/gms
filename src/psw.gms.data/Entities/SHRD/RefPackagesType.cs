/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;

namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the Ref_Packages_Type table in the database 
    /// </summary>
	public class RefPackagesType : Entity
	{
		#region Fields
		
		private int _package_Type_ID;
		private string _description;
		private string _transaction_Type;
		private bool _isActive;
		private string _manifest_Code;
		private string _manifest_Description;

		#endregion

		#region Properties
		
		public int Package_Type_ID { get { return _package_Type_ID; } set { _package_Type_ID = value; PrimaryKey = value; }}
		public string Description { get { return _description; } set { _description = value;  }}
		public string Transaction_Type { get { return _transaction_Type; } set { _transaction_Type = value;  }}
		public bool IsActive { get { return _isActive; } set { _isActive = value;  }}
		public string Manifest_Code { get { return _manifest_Code; } set { _manifest_Code = value;  }}
		public string Manifest_Description { get { return _manifest_Description; } set { _manifest_Description = value;  }}

		#endregion

		#region Methods

		#endregion

		#region public Methods

		public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object> 
			{
				{"Package_Type_ID", Package_Type_ID},
				{"Description", Description},
				{"Transaction_Type", Transaction_Type},
				{"IsActive", IsActive},
				{"Manifest_Code", Manifest_Code},
				{"Manifest_Description", Manifest_Description}
			};
        }

		#endregion

		#region Constructors
		
		#endregion
	}
} 

