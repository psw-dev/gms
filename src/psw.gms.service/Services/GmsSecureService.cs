using System.Collections.Generic;
using AutoMapper;
using PSW.GMS.Data;
using PSW.GMS.Service.Command;
using PSW.GMS.Service.Strategies;
using System.Security.Claims;
using PSW.Common.Crypto;
using PSW.Lib.Logs;

namespace PSW.GMS.Service
{
    public class GmsSecureService : IGmsSecureService
    {
        #region properties 
        public readonly IMapper _mapper;
        public IUnitOfWork UnitOfWork { get; set; }
        public IStrategyFactory StrategyFactory { get; set; }
        public IEnumerable<Claim> UserClaims { get; set; }
        public ICryptoAlgorithm CryptoAlgorithm { get; set; }
        public int LoggedInUserRoleId { get; set; }

        #endregion

        #region Constuctors & destroctors
        public GmsSecureService(IMapper mapper, ICryptoAlgorithm cryptoAlgorithm)
        {
            _mapper = mapper;
            this.CryptoAlgorithm = cryptoAlgorithm;
        }
        public GmsSecureService(IUnitOfWork unitOfWork, IStrategyFactory strategyFactory, ICryptoAlgorithm cryptoAlgorithm)
        {
            this.UnitOfWork = unitOfWork;
            this.StrategyFactory = strategyFactory;
            this.CryptoAlgorithm = cryptoAlgorithm;
            this.LoggedInUserRoleId = LoggedInUserRoleId;
        }
        public GmsSecureService()
        {
        }

        #endregion

        #region Invoke Function 
        /// <summary>
        /// Invoke method only for RPC service
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CommandReply Invoke(CommandRequest request)
        {
            try
            {
                // Initialize Mapper in Command Request 
                request._mapper = this._mapper;
                //check if UnitOfWork is set otherwise set the service's UoW as default
                request.UnitOfWork = request.UnitOfWork ?? this.UnitOfWork;
                // Check if CryptoAlgorith is set otherwise set the service's Crypto Algorithm as default              
                //create strategy based on request. it can be dynamic
                Strategy strategy = this.StrategyFactory.CreateStrategy(request);
                //validate request for strategy
                bool isValid = strategy.Validate();
                //Execute strategy
                var reply = isValid
                    ? strategy.Execute()
                    : strategy.BadRequestReply(strategy.ValidationMessage);
                return reply;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                request?.UnitOfWork?.CloseConnection();
            }
        }

        public CommandReply invokeMethod(CommandRequest request)
        {
            try
            {
                // Initialize Mapper in Command Request 
                request._mapper = this._mapper;
                //check if UnitOfWork is set otherwise set the service's UoW as default
                request.UnitOfWork = request.UnitOfWork ?? this.UnitOfWork;
                //check if UserClaims is set otherwise set the service's user claims as default
                request.UserClaims = request.UserClaims ?? this.UserClaims;
                // Check if CryptoAlgorith is set otherwise set the service's Crypto Algorithm as default
                request.CryptoAlgorithm = request.CryptoAlgorithm ?? this.CryptoAlgorithm;
                //create strategy based on request. it can be dynamic
                Strategy strategy = this.StrategyFactory.CreateStrategy(request);
                //validate request for strategy
                bool isValid = strategy.Validate();
                //Execute strategy
                var reply = isValid
                    ? strategy.Execute()
                    : strategy.BadRequestReply(strategy.ValidationMessage);
                return reply;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }

}