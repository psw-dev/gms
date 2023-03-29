using System;
using System.Text.Json.Serialization;

namespace PSW.GMS.Common
{
    public static class Config
    {
        public static string PSW_WEBOC_ENCRYPT_NAV_DATA_AUTH_BEARER => Environment.GetEnvironmentVariable("PSW_WEBOC_ENCRYPT_NAV_DATA_AUTH_BEARER");
        public static string PSW_APIENDPOINT_WEBOC_CREATE_TRADER => Environment.GetEnvironmentVariable("PSW_APIENDPOINT_WEBOC_CREATE_TRADER");
        public static string PSW_APIENDPOINT_WEBOC_CREATE_AGENT => Environment.GetEnvironmentVariable("PSW_APIENDPOINT_WEBOC_CREATE_AGENT");
        public static string PSW_APIENDPOINT_WEBOC_VERIFY_AGENT => Environment.GetEnvironmentVariable("PSW_APIENDPOINT_WEBOC_VERIFY_AGENT");
        public static string PSW_APIENDPOINT_WEBOC_EXAMINATION => Environment.GetEnvironmentVariable("PSW_APIENDPOINT_WEBOC_EXAMINATION");
        public static string PSW_APIENDPOINT_WEBOC_GENERAL => Environment.GetEnvironmentVariable("PSW_APIENDPOINT_WEBOC_GENERAL");
        public static string PSW_APIENDPOINT_WEBOC_GDP => Environment.GetEnvironmentVariable("PSW_APIENDPOINT_WEBOC_GDP");
        public static string PSW_METHOD_ID_WEBOC_GATE_IN_INQUIRY => Environment.GetEnvironmentVariable("PSW_METHOD_ID_WEBOC_GATE_IN_INQUIRY");
        public static string PSW_METHOD_ID_WEBOC_EXAMINATION_ARRANGEMENT => Environment.GetEnvironmentVariable("PSW_METHOD_ID_WEBOC_EXAMINATION_ARRANGEMENT");
        public static string PSW_METHOD_ID_WEBOC_EXAMINATION_COMPLETED => Environment.GetEnvironmentVariable("PSW_METHOD_ID_WEBOC_EXAMINATION_COMPLETED");
        public static string PSW_METHOD_ID_WEBOC_BLACKLIST_HSCODE => Environment.GetEnvironmentVariable("PSW_METHOD_ID_WEBOC_BLACKLIST_HSCODE");
        public static string PSW_METHOD_ID_WEBOC_CONTAINER_EXAMINATION_ARRANGEMENT => Environment.GetEnvironmentVariable("PSW_METHOD_ID_WEBOC_CONTAINER_EXAMINATION_ARRANGEMENT");
        public static string PSW_METHOD_ID_WEBOC_AGENCY_EXAMINATION_CONTAINER => Environment.GetEnvironmentVariable("PSW_METHOD_ID_WEBOC_AGENCY_EXAMINATION_CONTAINER");
    }

}