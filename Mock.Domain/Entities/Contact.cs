using Mock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Domain.Entities
{
    public class Contact : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public virtual EventrumUser ReferenceContact { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
    }
}
