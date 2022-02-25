using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Domain.Entities
{
    //Replace with application user when adding identity to the project
    public class EventrumUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required, NotNull]
        public string Email { get; set; }
        [Required, NotNull]
        public string TelephoneNumber { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
    }
}
