/*This code is a generated one , Change the source code of the generator if you want some change in this code
You can find the source code of the code generator from here -> https://git.psw.gov.pk/unais.vayani/DalGenerator*/

using System.Collections.Generic;
using PSW.GMS.Data.Entities;

namespace PSW.GMS.Data.Repositories
{
    public interface IPlantTypeBasedSelectionRepository : IRepository<PlantTypeBasedSelection>
    {
        List<PlantTypeBasedSelection> GetActivePlantBasedSelection();
    }
}
