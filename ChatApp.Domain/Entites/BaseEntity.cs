using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Entites
{
    public class BaseEntity
    {
        public int ID { get; set; }

        public DateTime CreationAt { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedAt {  get; set; }

      public  bool IsDeleted { get; set; }
       public bool IsActive { get; set; }

    }
}
