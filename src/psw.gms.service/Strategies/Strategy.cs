using AutoMapper;
using PSW.GMS.Service.Command;
using System.IO;
using System;
using PSW.GMS.Service.Mapper;

namespace PSW.GMS.Service.Strategies
{
    public class Strategy
    {
        public IMapper Mapper { get; protected set; }
        public CommandReply Reply { get; protected set; }
        public bool IsValidated { get; protected set; }
        public bool IsWorkflowRequest { get; set; }



        protected string StrategyName => GetType().Name;
        public string MethodName { get; protected set; }
        public CommandRequest Command { get; set; }
        public Strategy(CommandRequest request)
        {
            this.Command = request;
            this.IsValidated = false;
            Mapper = new ObjectMapper().GetMapper();
        }
        public virtual CommandReply Execute()
        {
            return null;
        }

        public string ValidationMessage { get; set; }
        public virtual bool Validate()
        {
            return this.IsValidated;
        }

        public virtual void log(string message)
        {
            string logPath = "/tmp/gms.log";
            File.AppendAllText(logPath, DateTime.Now.ToString("hhmmss") + " " + message + Environment.NewLine);
        }

        public virtual CommandReply BadRequestReply(string message)
        {
            Reply.code = "400"; // Bad Request | Error
            Reply.message = message;
            Reply.exception = null;
            return Reply;
        }
    }
}
