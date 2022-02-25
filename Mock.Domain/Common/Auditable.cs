using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Domain.Common
{
    public class Auditable
    {
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
