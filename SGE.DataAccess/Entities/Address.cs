using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.DataAccess.Entities
{
    public class Address : BaseEntity
    {
        public string Cep { get; set; }


        #region Relations
        public ICollection<School> Schools { get; set; }
        public ICollection<User> Users { get; set; }
        #endregion

        public Address()
        {
            Schools = new List<School>();
        }
    }
}
