using System;
using System.Collections.Generic;


namespace PSW.GMS.Data.Entities
{
    public class AgencyConfig : Entity
    {
        #region Fields

        private int _iD;
        private short _agencyID;
        private string _clientId;
        private string _clientSecret;
        private string _messageURL;
        private string _tokenURL;
        private string _grantType;
        private DateTime _createdOn;
        private DateTime _updatedOn;

        #endregion

        #region Properties

        public int ID { get { return _iD; } set { _iD = value; PrimaryKey = value; } }
        public short AgencyID { get { return _agencyID; } set { _agencyID = value; } }
        public string ClientId { get { return _clientId; } set { _clientId = value; } }
        public string ClientSecret { get { return _clientSecret; } set { _clientSecret = value; } }
        public string MessageURL { get { return _messageURL; } set { _messageURL = value; } }
        public string TokenURL { get { return _tokenURL; } set { _tokenURL = value; } }
        public string GrantType { get { return _grantType; } set { _grantType = value; } }
        public DateTime CreatedOn { get { return _createdOn; } set { _createdOn = value; } }
        public DateTime UpdatedOn { get { return _updatedOn; } set { _updatedOn = value; } }
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
                {"ClientId", ClientId},
                {"ClientSecret", ClientSecret},
                {"MessageURL", MessageURL},
                {"TokenURL", TokenURL},
                {"GrantType", GrantType},
                {"CreatedOn", CreatedOn},
                {"UpdatedOn", UpdatedOn}
            };
        }

        #endregion

        #region Constructors
        public AgencyConfig() : base()
        {
            TableName = "SHRD.dbo.AgencyConfig";
            PrimaryKeyName = "ID";
        }

        #endregion
    }
}
