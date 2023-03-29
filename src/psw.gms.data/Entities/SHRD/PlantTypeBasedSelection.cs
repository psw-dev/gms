using System;
using System.Collections.Generic;

namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the PlantTypeBasedSelection table in the database 
    /// </summary>
	public class PlantTypeBasedSelection : Entity
    {
        #region Fields

        private short _iD;
        private string _name;
        private short _plantTypeID;
        private bool? _isActive;
        private DateTime _efftctiveFromDate;
        private DateTime _effectiveThruDate;

        #endregion

        #region Properties

        public short ID { get { return _iD; } set { _iD = value; PrimaryKey = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public short PlantTypeID { get { return _plantTypeID; } set { _plantTypeID = value; } }
        public bool? IsActive { get { return _isActive; } set { _isActive = value; } }
        public DateTime EfftctiveFromDate { get { return _efftctiveFromDate; } set { _efftctiveFromDate = value; } }
        public DateTime EffectiveThruDate { get { return _effectiveThruDate; } set { _effectiveThruDate = value; } }

        #endregion

        #region Methods

        #endregion

        #region public Methods

        public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object>
            {
                {"ID", ID},
                {"Name", Name},
                {"PlantTypeID", PlantTypeID},
                {"IsActive", IsActive},
                {"EfftctiveFromDate", EfftctiveFromDate},
                {"EffectiveThruDate", EffectiveThruDate}
            };
        }

        #endregion

        #region Constructors
        public PlantTypeBasedSelection()
        {
            TableName = "[SHRD].[dbo].[PlantTypeBasedSelection]";
            PrimaryKeyName = "ID";
        }

        #endregion
    }
}

