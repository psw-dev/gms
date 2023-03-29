using System.Collections.Generic;


namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the PlantType table in the database 
    /// </summary>
	public class PlantType : Entity
    {
        #region Fields

        private short _iD;
        private string _name;

        #endregion

        #region Properties

        public short ID { get { return _iD; } set { _iD = value; PrimaryKey = value; } }
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
                {"Name", Name}
            };
        }

        #endregion

        #region Constructors

        #endregion
    }
}

