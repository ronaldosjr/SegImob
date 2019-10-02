using Sales.Domain.Entities.Common;

namespace Sales.Domain.Services.ValidationServices.Common
{
    public interface IValidationBeforePersist<TEntity> where TEntity:BaseEntity
    {
        bool CanPersist(TEntity entity);
    }
}
