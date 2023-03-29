/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;
using System.Linq;


namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the City table in the database 
    /// </summary>
	public class City : Entity
	{
		#region Fields
		
		private int _iD;
		private string _countryCode;
		private string _name;
		private string _parentCollectorateCode;
		private string _code;

        #endregion

		#region Properties

		public int ID { get { return _iD; } set { _iD = value; PrimaryKey = value; }}
		public string CountryCode { get { return _countryCode; } set { _countryCode = value;  }}
		public string Name { get { return _name; } set { _name = value;  }}
		public string ParentCollectorateCode { get { return _parentCollectorateCode; } set { _parentCollectorateCode = value;  }}
		public string Code { get { return _code; } set { _code = value;  }}

		#endregion

		#region Methods

		#endregion

		#region public Methods

		public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object> 
			{
				{"ID", ID},
				{"CountryCode", CountryCode},
				{"Name", Name},
				{"ParentCollectorateCode", ParentCollectorateCode},
				{"Code", Code}
            };
        }

		#endregion

		#region Constructors
		
		#endregion
	}
} 

