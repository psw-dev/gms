using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO;
using PSW.Lib.Logs;
using System;

using System.Reflection;

// using PSW.GMS.Service.DTO.ReleaseOrder.ReleaseOrderInformationDTO;

namespace PSW.GMS.Service.Helpers
{
    public class RabbitMqRequestBuilder : FormsTemplate
    {
        /// <summary>
        /// BuildReleaseOrderInfoRequestObject
        /// </summary>
        /// <param name="cmd">CommandRequest cmd</param>
        /// <param name="agencyID">long agencyID</param>
        /// <param name="sdid">long sdid</param>
        /// <returns>Rabbitmq request object</returns>
        public object BuildReleaseOrderInfoRequestObject(CommandRequest cmd, long agencyID, long sdid)
        {
            var encryptedSdid = cmd.CryptoAlgorithm.Encrypt(sdid.ToString());
            var requestObj = new
            {
                gdid = encryptedSdid,
                agencyId = agencyID,
            };

            return requestObj;
        }

        /// <summary>
        /// BuildImporterExporterInfoRequestObject
        /// </summary>
        /// <param name="cmd">CommandRequest cmd</param>
        /// <param name="agencyID">long agencyID</param>
        /// <param name="sdid"> long sdid</param>
        /// <returns>Rabbitmq request object</returns>
        public object BuildImporterExporterInfoRequestObject(CommandRequest cmd, long agencyID, long sdid)
        {
            var encryptedSdid = cmd.CryptoAlgorithm.Encrypt(sdid.ToString());
            var requestObj = new
            {
                gdid = encryptedSdid,
                agencyId = agencyID,
            };

            return requestObj;
        }

        /// <summary>
        /// BuildIGMInfoRequestObject
        /// </summary>
        /// <param name="IGMCompleteNumber">string IGMCompleteNumber</param>
        /// <param name="BLNumber">string BLNumber</param>
        /// <param name="collectorateID">int collectorateID</param>
        /// <param name="declarationTypeID">int declarationTypeID</param>
        /// <returns>Rabbitmq request object</returns>
        public object BuildIGMInfoRequestObject(string IGMCompleteNumber, string BLNumber, int collectorateID, int declarationTypeID)
        {
            var requestObj = new
            {
                igmCompleteNumber = IGMCompleteNumber,
                blNumber = BLNumber,
                gdCollectorateID = collectorateID,
                declarationTypeID = declarationTypeID
            };

            return requestObj;
        }

        /// <summary>
        /// BuildBLVIRInfoRequestObject
        /// </summary>
        /// <param name="index_No">int index_No</param>
        /// <param name="vessel_Registration_ID">int vessel_Registration_ID</param>
        /// <returns>Rabbitmq request object</returns>
        public object BuildBLVIRInfoRequestObject(int index_No, int vessel_Registration_ID)
        {
            var requestObj = new
            {
                indexNumber = index_No,
                vesselRegID = vessel_Registration_ID
            };

            return requestObj;
        }

        /// <summary>
        /// BuildGDInfoRequestObject
        /// </summary>
        /// <param name="cmd">CommandRequest cmd</param>
        /// <param name="agencyID"> long agencyID</param>
        /// <param name="sdid">long sdid</param>
        /// <returns></returns>
        public object BuildGDInfoRequestObject(CommandRequest cmd, long agencyID, long sdid)
        {
            var encryptedSdid = cmd.CryptoAlgorithm.Encrypt(sdid.ToString());
            var requestObj = new
            {
                sdid = encryptedSdid,
                agencyId = agencyID
            };

            return requestObj;
        }

        public object BuildPSIReportRequestObject(CommandRequest cmd, string ntn, string blNumber, string blDate)
        {
            var requestObj = new
            {
                ntn = ntn,
                blNumber = blNumber,
                blDate = blDate
            };

            return requestObj;
        }
    }
}