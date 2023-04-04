using AutoMapper;
using PSW.GMS.Common.Constants;
using PSW.GMS.Data.Entities;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.DTO;
using PSW.Security.Signature;
using System;
using System.Linq;
using System.Text.Json;

namespace PSW.GMS.Service.Managers
{
    public static class WokerJobManager
    {

        /// <summary>
        /// AddJobForAD- add record in ADWokerJob table, so the woker service will 
        /// fetch records from db and try to send http calls to designatied AD
        /// </summary>
        /// <param name="cmd">cmd</param>
        /// <param name="requestPayload">requestPayload</param>
        /// <param name="methodId">methodId</param>
        /// <param name="receivingAgency">receivingAgency</param>
        /// <param name="url">url</param>
        public static void addJobForEDI(CommandRequest cmd, Object requestPayload, string processingCode, string receivingAgency, string url)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}