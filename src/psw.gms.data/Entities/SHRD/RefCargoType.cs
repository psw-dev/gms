/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;
using System.Linq;


namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the Ref_Cargo_Type table in the database 
    /// </summary>
	public class RefCargoType : Entity
	{
		#region Fields
		
		private long _cargo_ID;
		private string _cargo_Name;
		private string _description;
		private bool? _isActive;
		private string _transaction_Type;
		private int? _parent_Cargo_ID;

		#endregion

		#region Properties
		
		public long Cargo_ID { get { return _cargo_ID; } set { _cargo_ID = value; PrimaryKey = value; }}
		public string Cargo_Name { get { return _cargo_Name; } set { _cargo_Name = value;  }}
		public string Description { get { return _description; } set { _description = value;  }}
		public bool? IsActive { get { return _isActive; } set { _isActive = value;  }}
		public string Transaction_Type { get { return _transaction_Type; } set { _transaction_Type = value;  }}
		public int? Parent_Cargo_ID { get { return _parent_Cargo_ID; } set { _parent_Cargo_ID = value;  }}

		#endregion

		#region Methods

		#endregion

		#region public Methods

		public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object> 
			{
				{"Cargo_ID", Cargo_ID},
				{"Cargo_Name", Cargo_Name},
				{"Description", Description},
				{"IsActive", IsActive},
				{"Transaction_Type", Transaction_Type},
				{"Parent_Cargo_ID", Parent_Cargo_ID}
			};
        }

		#endregion

		#region Constructors
		
		#endregion
	}
} 

