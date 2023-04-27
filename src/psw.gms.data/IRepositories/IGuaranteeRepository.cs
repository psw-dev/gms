using PSW.GMS.Data.Entities;

namespace PSW.GMS.Data.Repositories
{
    public interface IGuaranteeRepository : IRepository<Guarantee>
    {
        string GetCountForGURNumber();
        string RestartCounterForGURNumber(string dateFormat);
    }
}