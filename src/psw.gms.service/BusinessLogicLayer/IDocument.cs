using System.Collections.Generic;
using PSW.GMS.Data.Entities;

namespace PSW.GMS.Service.BusinessLogicLayer
{
    public interface IDocument
    {
        int validate(Guarantee gurEntity, out string responseMessage);
        int Create(ref Guarantee gurEntity, out string responseMessage);
        int Delete(long ID, out string responseMessage);
        int Update(Guarantee gurEntity, out string responseMessage);
        IEnumerable<Entity> Get(long ID);
        string GetDocNumber();
    }
}