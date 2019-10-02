using Microsoft.EntityFrameworkCore;

namespace Sales.Infra.Context
{
    public interface IConnection
    {
        DbContext Context();
        void Commit();
    }
}
