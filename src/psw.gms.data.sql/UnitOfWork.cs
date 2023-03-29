/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

using PSW.GMS.Common;
using PSW.GMS.Data.Repositories;
using PSW.GMS.Data.Sql.Repositories;
// using PSW.Repositories;
// using PSW.Sql.Repositories;
using PSW.RabbitMq;


namespace PSW.GMS.Data.Sql
{

    public class UnitOfWork : IUnitOfWork
    {

        #region Private Properties SHRD
        private IAgencyRepository _agencyRepository;
        private ICatchSourceRepository _catchSourceRepository;
        private IAgencyConfigRepository _agencyConfigRepository;
        private IAgencySiteRepository _agencySiteRepository;
        private IAppConfigRepository _appConfigRepository;
        private IAttachedObjectFormatRepository _attachedObjectFormatRepository;
        private IAttachmentStatusRepository _attachmentStatusRepository;
        private IClassificationRepository _classificationRepository;
        private ICityRepository _cityRepository;
        private ICountryRepository _countryRepository;
        private ICertifiedCommoditiesRepository _certifiedCommoditiesRepository;
        private ICountrySubEntityRepository _countrySubEntityRepository;
        private ICurrencyRepository _currencyRepository;
        private IDialingCodeRepository _dialingCodeRepository;
        private IDocumentTypeRepository _documentTypeRepository;
        private IGenderRepository _genderRepository;
        private IMinistryRepository _ministryRepository;
        private IMeansOfConveyanaceRepository _meansOfConveyanaceRepository;
        private IPortRepository _portRepository;
        private ITradePurposeRepository _tradePurposeRepository;
        private ITradeTranTypeRepository _tradeTranTypeRepository;
        private ITypesOfPestRepository _typesOfPestRepository;
        private ITypesOfTimberRepository _typesOfTimberRepository;
        private IUoMRepository _uoMRepository;
        private IZoneRepository _zoneRepository;
        private IRefPackagesTypeRepository _refPackagesTypeRepository;
        private IRefShedLocationsRepository _refShedLocationRepository;
        private IRefUnitsRepository _refUnitsRepository;
        private IRefCargoTypeRepository _refCargoTypeRepository;
        private ICustomsCollectoratesRepository _customsCollectoratesRepository;
        private IIRMSEnabledDocumentTypeRepository _IRMSEnabledDocumentTypeRepository;
        private ITreatmentTypeRepository _treatmentTypeRepository;
        private IWaterAreaTypeRepository _waterAreaTypeRepository;
        private IFirmStatusRepository _firmStatusRepository;
        private IAllowedDocumentReviewCountRepository _allowedDocumentReviewCountRepository;
        private IDocumentTypeBasedPlantTypeRepository _documentTypeBasedPlantTypeRepository;
        private IPlantTypeRepository _plantTypeRepository;
        private IPlantTypeBasedSelectionRepository _plantTypeBasedSelectionRepository;
        private IProcessingEquipmentRepository _processingEquipmentRepository;
        private IStorageTypeRepository _storageTypeRepository;
        private IDocumentAllowedOperationsRepository _documentAllowedOperationsRepository;

        #endregion

        #region Private Properties SHRD Views

        #endregion

        #region Public Properties SHRD

        public IAgencyRepository AgencyRepository => _agencyRepository ?? (_agencyRepository = new AgencyRepository(_connection));
        public ICatchSourceRepository CatchSourceRepository => _catchSourceRepository ?? (_catchSourceRepository = new CatchSourceRepository(_connection));
        public IAgencySiteRepository AgencySiteRepository => _agencySiteRepository ?? (_agencySiteRepository = new AgencySiteRepository(_connection));
        public IAppConfigRepository AppConfigRepository => _appConfigRepository ?? (_appConfigRepository = new AppConfigRepository(_connection));
        public IAttachedObjectFormatRepository AttachedObjectFormatRepository => _attachedObjectFormatRepository ?? (_attachedObjectFormatRepository = new AttachedObjectFormatRepository(_connection));
        public IAttachmentStatusRepository AttachmentStatusRepository => _attachmentStatusRepository ?? (_attachmentStatusRepository = new AttachmentStatusRepository(_connection));
        public IClassificationRepository ClassificationRepository => _classificationRepository ?? (_classificationRepository = new ClassificationRepository(_connection));
        public ICityRepository CityRepository => _cityRepository ?? (_cityRepository = new CityRepository(_connection));
        public ICountryRepository CountryRepository => _countryRepository ?? (_countryRepository = new CountryRepository(_connection));
        public ICertifiedCommoditiesRepository CertifiedCommoditiesRepository => _certifiedCommoditiesRepository ?? (_certifiedCommoditiesRepository = new CertifiedCommoditiesRepository(_connection));
        public ICountrySubEntityRepository CountrySubEntityRepository => _countrySubEntityRepository ?? (_countrySubEntityRepository = new CountrySubEntityRepository(_connection));
        public ICurrencyRepository CurrencyRepository => _currencyRepository ?? (_currencyRepository = new CurrencyRepository(_connection));
        public IDialingCodeRepository DialingCodeRepository => _dialingCodeRepository ?? (_dialingCodeRepository = new DialingCodeRepository(_connection));
        public IDocumentTypeRepository DocumentTypeRepository => _documentTypeRepository ?? (_documentTypeRepository = new DocumentTypeRepository(_connection));
        public IGenderRepository GenderRepository => _genderRepository ?? (_genderRepository = new GenderRepository(_connection));
        public IMinistryRepository MinistryRepository => _ministryRepository ?? (_ministryRepository = new MinistryRepository(_connection));
        public IMeansOfConveyanaceRepository MeansOfConveyanaceRepository => _meansOfConveyanaceRepository ?? (_meansOfConveyanaceRepository = new MeansOfConveyanaceRepository(_connection));
        public IPortRepository PortRepository => _portRepository ?? (_portRepository = new PortRepository(_connection));
        public ITradePurposeRepository TradePurposeRepository => _tradePurposeRepository ?? (_tradePurposeRepository = new TradePurposeRepository(_connection));
        public ITradeTranTypeRepository TradeTranTypeRepository => _tradeTranTypeRepository ?? (_tradeTranTypeRepository = new TradeTranTypeRepository(_connection));
        public ITypesOfPestRepository TypesOfPestRepository => _typesOfPestRepository ?? (_typesOfPestRepository = new TypesOfPestRepository(_connection));
        public ITypesOfTimberRepository TypesOfTimberRepository => _typesOfTimberRepository ?? (_typesOfTimberRepository = new TypesOfTimberRepository(_connection));
        public IUoMRepository UoMRepository => _uoMRepository ?? (_uoMRepository = new UoMRepository(_connection));
        public IZoneRepository ZoneRepository => _zoneRepository ?? (_zoneRepository = new ZoneRepository(_connection));
        public IRefPackagesTypeRepository RefPackagesTypeRepository => _refPackagesTypeRepository ?? (_refPackagesTypeRepository = new RefPackagesTypeRepository(_connection));
        public ICustomsCollectoratesRepository CustomsCollectoratesRepository => _customsCollectoratesRepository ?? (_customsCollectoratesRepository = new CustomsCollectoratesRepository(_connection));

        public IRefShedLocationsRepository RefShedLocationsRepository => _refShedLocationRepository ?? (_refShedLocationRepository = new RefShedLocationsRepository(_connection));
        public IRefUnitsRepository RefUnitsRepository => _refUnitsRepository ?? (_refUnitsRepository = new RefUnitsRepository(_connection));
        public IRefCargoTypeRepository RefCargoTypeRepository => _refCargoTypeRepository ?? (_refCargoTypeRepository = new RefCargoTypeRepository(_connection));

        public IIRMSEnabledDocumentTypeRepository IRMSEnabledDocumentTypeRepository => _IRMSEnabledDocumentTypeRepository ?? (_IRMSEnabledDocumentTypeRepository = new IRMSEnabledDocumentTypeRepository(_connection));
        public IAgencyConfigRepository AgencyConfigRepository => _agencyConfigRepository ?? (_agencyConfigRepository = new AgencyConfigRepository(_connection));
        public ITreatmentTypeRepository TreatmentTypeRepository => _treatmentTypeRepository ?? (_treatmentTypeRepository = new TreatmentTypeRepository(_connection));
        public IWaterAreaTypeRepository WaterAreaTypeRepository => _waterAreaTypeRepository ?? (_waterAreaTypeRepository = new WaterAreaTypeRepository(_connection));
        public IFirmStatusRepository FirmStatusRepository => _firmStatusRepository ?? (_firmStatusRepository = new FirmStatusRepository(_connection));

        public IAllowedDocumentReviewCountRepository AllowedDocumentReviewCountRepository => _allowedDocumentReviewCountRepository ?? (_allowedDocumentReviewCountRepository = new AllowedDocumentReviewCountRepository(_connection));
        public IDocumentAllowedOperationsRepository DocumentAllowedOperationsRepository => _documentAllowedOperationsRepository ?? (_documentAllowedOperationsRepository = new DocumentAllowedOperationsRepository(_connection));

        public IDocumentTypeBasedPlantTypeRepository DocumentTypeBasedPlantTypeRepository => _documentTypeBasedPlantTypeRepository ?? (_documentTypeBasedPlantTypeRepository = new DocumentTypeBasedPlantTypeRepository(_connection));
        public IPlantTypeRepository PlantTypeRepository => _plantTypeRepository ?? (_plantTypeRepository = new PlantTypeRepository(_connection));
        public IPlantTypeBasedSelectionRepository PlantTypeBasedSelectionRepository => _plantTypeBasedSelectionRepository ?? (_plantTypeBasedSelectionRepository = new PlantTypeBasedSelectionRepository(_connection));
        public IStorageTypeRepository StorageTypeRepository => _storageTypeRepository ?? (_storageTypeRepository = new StorageTypeRepository(_connection));
        public IProcessingEquipmentRepository ProcessingEquipmentRepository => _processingEquipmentRepository ?? (_processingEquipmentRepository = new ProcessingEquipmentRepository(_connection));

        #endregion

        //EventBusXml to Send request to IRMS
        private IEventBus _eventBus;

        public IEventBus eventBus => _eventBus;
        //private IEventBus _eventBus;

        //public IEventBus eventBus => _eventBus;
        private IConfiguration _configuration;

        public UnitOfWork(IConfiguration configuration, IEventBus evBus)
        {
            _eventBus = evBus;
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));

        }
        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
        }
        public UnitOfWork()
        {
            // TODO : Get Connection String From appSetting.json
            string connectionString = "Server=127.0.0.1;Initial Catalog=GMS;User ID=sa;Password=@Password1;";
            _connection = new SqlConnection(connectionString);
            // _connection.Open();
        }

        public UnitOfWork(string connectionString)
        {

            _connection = new SqlConnection(connectionString);
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null) _connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));

                return _connection;
            }

            set
            {
                _connection = value;
            }
        }

        #region Private variables 
        private IDbConnection _connection; // = new SqlConnection(_configuration.GetConnectionString("SQLConnectionString")); ;	
        private IDbTransaction _transaction;
        #endregion


        #region Public methods

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }

        public List<object> ExecuteQuery(string query)
        {
            return (List<object>)_connection.Query<List<object>>(query);
        }

        public void OpenConnection()
        {
            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void CloseConnection()
        {
            try
            {
                //if (_transaction != null)
                //    _transaction.Commit();
                if (_connection != null && _connection.State != ConnectionState.Closed)
                    Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void BeginTransaction()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                _transaction = _connection.BeginTransaction();

                SetTransactions(_transaction);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void SetTransactions(IDbTransaction transaction)
        {
            var repositories = this.GetType().GetProperties();

            foreach (PropertyInfo r in repositories)
            {
                if (Utility.IsAssignableToGenericType(r.PropertyType, typeof(Data.Repositories.IRepository<>)))
                {

                    var repo = r.GetValue(this) as IRepositoryTransaction;
                    repo.SetTransaction(transaction);

                }
            }
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null)
                    _transaction.Commit();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null)
                    _transaction.Rollback();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
