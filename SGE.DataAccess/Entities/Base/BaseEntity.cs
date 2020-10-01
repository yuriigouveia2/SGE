using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.DataAccess.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        #region Model validation field
        public bool IsValid { get; set; }
        #endregion
    }
}
