
using System;
using System.Collections.Generic;
using System.Linq;


namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the MeansOfConveyanace table in the database 
    /// </summary>
	public class MeansOfConveyanace : Entity
    {
        #region Fields

        private int _iD;
        private string _name;
        private bool _isActive;

        #endregion

        #region Properties

        public int ID { get { return _iD; } set { _iD = value; PrimaryKey = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public bool IsActive { get { return _isActive; } set { _isActive = value; } }

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
                {"IsActive", IsActive},
            };
        }

        #endregion

        #region Constructor


        #endregion
    }
}

