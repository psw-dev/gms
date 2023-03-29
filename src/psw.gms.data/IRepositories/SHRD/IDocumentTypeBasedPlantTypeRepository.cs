
using System.Collections.Generic;
using PSW.GMS.Data.Entities;

namespace PSW.GMS.Data.Repositories
{
    public interface IDocumentTypeBasedPlantTypeRepository : IRepository<DocumentTypeBasedPlantType>
    {
        List<DocumentBasedPlantTypeDTO> GetDocumentBasedPlantTypes(string documentTypeCode);
    }
}
