namespace PSW.GMS.Common.Constants
{
    public static class EDIWokerConfig
    {
        public const string GMSWorkerMaxRetryAttempts = "GMSWorkerMaxRetryAttempts";
        public const string DefaultGMSWorkerMaxRetryAttempts = "5";
    }

    public static class EDIAgencyConstants
    {
        public const string PSW = "PSW";
        public const string PSQCA = "PSQ";

    }

    public static class EDIProcessingCodeas
    {
        public const string ShareSDInfo = "1801";
        public const string ShareCalledDocuments = "1802";
        public const string ShareInspectionDetails = "1807";
        public const string ShareLabPaymentReceival = "1805";
        public const string ShareReviewMessage = "1806";
        public const string SendSDCancellationMessage = "1820";

    }

    public static class ReleaseCertificateTypeCode
    {
        public const string NCAR = "01";
        public const string CAR = "02";
        public const string TRC = "03";
        public const string RC = "04";

    }

}
