/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;
using System.Linq;


namespace PSW.GMS.Data.Entities
{
    /// <summary>
    /// This class represents the Agency table in the database 
    /// </summary>
    public class AgencySite : Entity
    {
        #region Fields

        private int _iD;
        private short _agencyID;
        private string _name;
        private DateTime _createdOn;
        private int _createdBy;
        private DateTime _updatedOn;
        private int _updatedBy;
        private int? _cityID;
        private string _numStreetPOBox;
        private string _countryCode;
        private string _countrySubEntityCode;
        private string _postalCode;
        private string _agencySiteAddress;

        #endregion

        #region Properties

        public int ID { get { return _iD; } set { _iD = value; PrimaryKey = value; } }
        public short AgencyID { get { return _agencyID; } set { _agencyID = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public DateTime CreatedOn { get { return _createdOn; } set { _createdOn = value; } }
        public int CreatedBy { get { return _createdBy; } set { _createdBy = value; } }
        public DateTime UpdatedOn { get { return _updatedOn; } set { _updatedOn = value; } }
        public int UpdatedBy { get { return _updatedBy; } set { _updatedBy = value; } }
        public int? CityID { get { return _cityID; } set { _cityID = value; } }
        public string NumStreetPOBox { get { return _numStreetPOBox; } set { _numStreetPOBox = value; } }
        public string CountryCode { get { return _countryCode; } set { _countryCode = value; } }
        public string CountrySubEntityCode { get { return _countrySubEntityCode; } set { _countrySubEntityCode = value; } }
        public string PostalCode { get { return _postalCode; } set { _postalCode = value; } }
        public string AgencySiteAddress { get { return _agencySiteAddress; } set { _agencySiteAddress = value; } }

        #endregion

        #region Methods

        #endregion

        #region public Methods

        public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object>
            {
                {"ID", ID},
                {"AgencyID", AgencyID},
                {"Name", Name},
                {"CreatedOn", CreatedOn},
                {"CreatedBy", CreatedBy},
                {"UpdatedOn", UpdatedOn},
                {"UpdatedBy", UpdatedBy},
                {"CityID", CityID},
                {"NumStreetPOBox", NumStreetPOBox},
                {"CountryCode", CountryCode},
                {"CountrySubEntityCode", CountrySubEntityCode},
                {"PostalCode", PostalCode},
                {"AgencySiteAddress", AgencySiteAddress}
            };
        }

        #endregion

        #region Constructors

        public AgencySite()
        {
            TableName = "[SHRD].[dbo].[AgencySite]";
            PrimaryKeyName = "ID";
        }

        #endregion
    }
}

