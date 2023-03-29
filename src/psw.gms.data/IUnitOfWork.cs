/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System;
using PSW.GMS.Data.Repositories;
using PSW.RabbitMq;
// using PSW.Repositories;

namespace PSW.GMS.Data
{
    public interface IUnitOfWork : IDisposable
    {

        #region Rabbit MQ
        IEventBus eventBus { get; }

        #endregion

        #region SHRD Repositories

        IAgencyRepository AgencyRepository { get; }
        ICatchSourceRepository CatchSourceRepository { get; }
        IAgencySiteRepository AgencySiteRepository { get; }
        IAppConfigRepository AppConfigRepository { get; }
        IAttachedObjectFormatRepository AttachedObjectFormatRepository { get; }
        IAttachmentStatusRepository AttachmentStatusRepository { get; }
        IClassificationRepository ClassificationRepository { get; }
        ICityRepository CityRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICertifiedCommoditiesRepository CertifiedCommoditiesRepository { get; }
        ICountrySubEntityRepository CountrySubEntityRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        IDialingCodeRepository DialingCodeRepository { get; }
        IDocumentTypeRepository DocumentTypeRepository { get; }
        IGenderRepository GenderRepository { get; }
        IMinistryRepository MinistryRepository { get; }
        IMeansOfConveyanaceRepository MeansOfConveyanaceRepository { get; }
        IPortRepository PortRepository { get; }
        ITradePurposeRepository TradePurposeRepository { get; }
        ITradeTranTypeRepository TradeTranTypeRepository { get; }
        ITypesOfPestRepository TypesOfPestRepository { get; }
        ITypesOfTimberRepository TypesOfTimberRepository { get; }
        IUoMRepository UoMRepository { get; }
        IZoneRepository ZoneRepository { get; }
        IRefShedLocationsRepository RefShedLocationsRepository { get; }
        IRefUnitsRepository RefUnitsRepository { get; }
        IRefPackagesTypeRepository RefPackagesTypeRepository { get; }
        IRefCargoTypeRepository RefCargoTypeRepository { get; }
        ICustomsCollectoratesRepository CustomsCollectoratesRepository { get; }
        IIRMSEnabledDocumentTypeRepository IRMSEnabledDocumentTypeRepository { get; }
        IAgencyConfigRepository AgencyConfigRepository { get; }
        ITreatmentTypeRepository TreatmentTypeRepository { get; }
        IWaterAreaTypeRepository WaterAreaTypeRepository { get; }
        IFirmStatusRepository FirmStatusRepository { get; }
        IDocumentAllowedOperationsRepository DocumentAllowedOperationsRepository { get; }

        IStorageTypeRepository StorageTypeRepository { get; }
        IPlantTypeRepository PlantTypeRepository { get; }
        IPlantTypeBasedSelectionRepository PlantTypeBasedSelectionRepository { get; }
        IDocumentTypeBasedPlantTypeRepository DocumentTypeBasedPlantTypeRepository { get; }
        IProcessingEquipmentRepository ProcessingEquipmentRepository { get; }

        #endregion

        #region SHRD View Repositories
        #endregion

        #region Methods
        void BeginTransaction();
        void Commit();
        void Rollback();

        void OpenConnection();
        void CloseConnection();

        #endregion
    }
}
