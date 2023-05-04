using System.Collections.Generic;
using PSW.GMS.Data.Entities;
using PSW.GMS.Service.DTO;

namespace PSW.GMS.Service.BusinessLogicLayer
{
    public interface IDocument
    {
        int Create(string roleCode, ref Guarantee gurEntity, out string responseMessage);
        int Get(GetGuaranteeRequestDTO requestDTO, int subscriptionID, int userRoleId, int parentRoleID, int loggedInUserRoleId, string ParentCollectorateCode, out IEnumerable<Guarantee> entities, out string responseMessage);
        int Update(Guarantee gurEntity, out string responseMessage);
        int Delete(long ID, out string responseMessage);
        string GetDocNumber();
        int validateCreateGurRequest(string roleCode, Guarantee gurEntity, out string responseMessage);
    }
}