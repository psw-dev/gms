/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Collections.Generic;


namespace PSW.GMS.Data.Entities
{
    public class WorkerJobs : Entity
    {
        #region Fields

        private long _iD;
        private string _sourceCode;
        private string _destinationCode;
        private string _sourceEndpoint;
        private string _destinationEndpoint;
        private string _methodID;
        private string _requestPayLoad;
        private string _responsePayLoad;
        private int _workerJobStatusID;
        private int _attempts;
        private DateTime _createdOn;
        private DateTime _updatedOn;
        private int _remainingAttempts;
        private int _workerPriority;
        #endregion

        #region Properties

        public long ID { get { return _iD; } set { _iD = value; PrimaryKey = value; } }
        public string SourceCode { get { return _sourceCode; } set { _sourceCode = value; } }
        public string DestinationCode { get { return _destinationCode; } set { _destinationCode = value; } }
        public string SourceEndpoint { get { return _sourceEndpoint; } set { _sourceEndpoint = value; } }
        public string DestinationEndpoint { get { return _destinationEndpoint; } set { _destinationEndpoint = value; } }
        public string MethodID { get { return _methodID; } set { _methodID = value; } }
        public string RequestPayLoad { get { return _requestPayLoad; } set { _requestPayLoad = value; } }
        public string ResponsePayLoad { get { return _responsePayLoad; } set { _responsePayLoad = value; } }
        public int WorkerJobStatusID { get { return _workerJobStatusID; } set { _workerJobStatusID = value; } }
        public int Attempts { get { return _attempts; } set { _attempts = value; } }
        public DateTime CreatedOn { get { return _createdOn; } set { _createdOn = value; } }
        public DateTime UpdatedOn { get { return _updatedOn; } set { _updatedOn = value; } }
        public int RemainingAttempts { get { return _remainingAttempts; } set { _remainingAttempts = value; } }
        public int WorkerPriority { get { return _workerPriority; } set { _workerPriority = value; } }

        #endregion

        #region Methods

        #endregion

        #region public Methods

        public override Dictionary<string, object> GetColumns()
        {
            return new Dictionary<string, object>
            {
                {"ID", ID},
                {"SourceCode", SourceCode},
                {"DestinationCode", DestinationCode},
                {"SourceEndpoint", SourceEndpoint},
                {"DestinationEndpoint", DestinationEndpoint},
                {"MethodID", MethodID},
                {"RequestPayLoad", RequestPayLoad},
                {"ResponsePayLoad", ResponsePayLoad},
                {"WorkerJobStatusID", WorkerJobStatusID},
                {"Attempts", Attempts},
                {"CreatedOn", CreatedOn},
                {"UpdatedOn", UpdatedOn},
                {"RemainingAttempts", RemainingAttempts},
                // {"WorkerPriority", WorkerPriority}
            };
        }

        #endregion

        #region Constructors

        public WorkerJobs() : base()
        {
            TableName = "WorkerJobs";
            PrimaryKeyName = "ID";
        }

        #endregion
    }
}

