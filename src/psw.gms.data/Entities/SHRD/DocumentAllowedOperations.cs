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
    public class DocumentAllowedOperations : Entity
    {
        #region Fields

        private long _iD;
        private int _doID;
        private string _docTypeCode;
        private short _agencyID;
        private int _tradeTranTypeId;
        private string _displayName;
        private string _documentClassificationCode;



        #endregion

        #region Properties

        public long ID { get { return _iD; } set { _iD = value; PrimaryKey = value; } }
        public int DoID { get { return _doID; } set { _doID = value; } }
        public string DocTypeCode { get { return _docTypeCode; } set { _docTypeCode = value; } }
        public short AgencyID { get { return _agencyID; } set { _agencyID = value; } }
        public int TradeTranTypeId { get { return _tradeTranTypeId; } set { _tradeTranTypeId = value; } }
        public string DisplayName { get { return _displayName; } set { _displayName = value; } }
        public string DocumentClassificationCode { get { return _documentClassificationCode; } set { _documentClassificationCode = value; } }



        #endregion

        #region Methods

        #endregion

        #region public Methods

        public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object>
            {
                {"ID", ID},
                {"DOID", DoID},
                {"DocTypeCode", DocTypeCode},
                {"AgencyID", AgencyID},
                 {"TradeTranTypeId", TradeTranTypeId},
                {"DisplayName", DisplayName},
                {"DocumentClassificationCode", DocumentClassificationCode},

            };
        }

        #endregion

        #region Constructors

        public DocumentAllowedOperations()
        {
            TableName = "[SHRD].[dbo].[DocumentAllowedOperations]";
            PrimaryKeyName = "ID";
        }

        #endregion
    }
}

