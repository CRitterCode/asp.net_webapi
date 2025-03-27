using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table(nameof(User))]
    public class User : EntityGuidBase
    {
        public ICollection<Business> Businesses { get; set; }
    }
}
