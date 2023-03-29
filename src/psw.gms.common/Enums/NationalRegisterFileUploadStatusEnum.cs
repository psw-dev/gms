
using System.ComponentModel;

namespace PSW.GMS.Common.Enums
{
    public enum NationalRegisterFileUploadStatusEnum
    {

        [Description("In Progress")]
        IN_PROGRESS = 1,
        [Description("Processed")]
        PROCESSED = 2,
        [Description("Failed")]
        FAILED = 3,
        [Description("Cancelled")]
        CANCELLED = 4,
    }
}