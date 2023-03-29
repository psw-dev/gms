/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;
using System.Linq;


namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the CertifiedCommodities table in the database 
    /// </summary>
	public class CertifiedCommodities : Entity
    {
        #region Fields

        private short _id;
        private bool _isActive;
        private string _name;

        #endregion

        #region Properties

        public short ID { get { return _id; } set { _id = value; PrimaryKey = value; } }
        public bool IsActive { get { return _isActive; } set { _isActive = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        #endregion

        #region Methods

        #endregion

        #region public Methods

        public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object>
            {
                {"ID", ID},
                {"IsActive", IsActive},
                {"Name", Name}
            };
        }

        #endregion

        #region Constructors

        #endregion
    }
}

