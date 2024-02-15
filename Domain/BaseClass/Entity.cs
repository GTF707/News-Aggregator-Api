using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PersistentObj
{
    public abstract class Entity<TId>
    {
        public virtual TId Id { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual DateTime? DateDelete { get; set; }
    }
}
