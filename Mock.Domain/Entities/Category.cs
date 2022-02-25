using Mock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Domain.Entities
{
    public class Category : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
