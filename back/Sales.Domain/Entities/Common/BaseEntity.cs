using System;

namespace Sales.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public abstract bool IsValid();

        protected BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
    }
}
