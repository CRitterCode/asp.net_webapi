using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : EntityBase
    {
        public ICollection<Buisness> Buisnesses { get; set; } = new Collection<Buisness>();
    }
}
