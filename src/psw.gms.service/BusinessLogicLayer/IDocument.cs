using System.Collections.Generic;
using PSW.GMS.Data.Entities;

namespace PSW.GMS.Service.BusinessLogicLayer
{
    public interface IDocument
    {
        int validate(Guarantee gurEntity, ref string responseMessage);
        int Create(ref Guarantee gurEntity, ref string responseMessage);
        int Delete(long ID, ref string responseMessage);
        int Update(Guarantee gurEntity, ref string responseMessage);
        IEnumerable<Entity> Get(long ID);
        string GetDocNumber();
    }
}