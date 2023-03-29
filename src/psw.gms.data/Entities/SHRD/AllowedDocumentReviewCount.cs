using System.Collections.Generic;

namespace PSW.GMS.Data.Entities
{
    public class AllowedDocumentReviewCount : Entity
    {
        #region Fields

        private int _iD;
        private string _documentTypeCode;
        private short _allowedReviews;

        #endregion

        #region Properties

        public int ID { get { return _iD; } set { _iD = value; PrimaryKey = value; } }
        public string DocumentTypeCode { get { return _documentTypeCode; } set { _documentTypeCode = value; } }
        public short AllowedReviews { get { return _allowedReviews; } set { _allowedReviews = value; } }
        #endregion

        #region Methods

        #endregion

        #region public Methods

        public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object>
            {
                {"ID", ID},
                {"DocumentTypeCode", DocumentTypeCode},
                {"AllowedReviews", AllowedReviews}
            };
        }

        #endregion

        #region Constructors

        #endregion
    }
}

