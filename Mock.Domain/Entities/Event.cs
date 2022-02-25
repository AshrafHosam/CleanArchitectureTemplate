using Mock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Domain.Entities
{
    public class Event : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EventStatus { get; set; }
        public virtual Category Category { get; set; }
        public virtual EventrumUser EventOwner { get; set; }

        //Add here more needed attributes
    }

    public enum EventStatus
    {
        Current,
        Live,
        ComingSoon
    }
}
