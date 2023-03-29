/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;
using System.Linq;


namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the Ref_Units table in the database 
    /// </summary>
	public class RefUnits : Entity
    {
        #region Fields

        private short _unit_ID;
        private string _unit_Code;
        private string _unit_Description;
        private string _tERMID;
        private bool? _isActive;

        #endregion

        #region Properties

        public short Unit_ID { get { return _unit_ID; } set { _unit_ID = value; PrimaryKey = value; } }
        public string Unit_Code { get { return _unit_Code; } set { _unit_Code = value; } }
        public string Unit_Description { get { return _unit_Description; } set { _unit_Description = value; } }
        public string TERMID { get { return _tERMID; } set { _tERMID = value; } }
        public bool? IsActive { get { return _isActive; } set { _isActive = value; } }

        #endregion

        #region Methods

        #endregion

        #region public Methods

        public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object>
            {
                {"Unit_ID", Unit_ID},
                {"Unit_Code", Unit_Code},
                {"Unit_Description", Unit_Description},
                {"TERMID", TERMID},
                {"IsActive", IsActive}
            };
        }

        #endregion

        #region Constructors

        #endregion
    }
}

