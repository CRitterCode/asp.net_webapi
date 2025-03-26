using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Service
{
    [Table(nameof(ServiceType))]
    public class ServiceType : EntityBase
    {
        public string Name { get; set; } = string.Empty;

        //relation
        public ICollection<ServiceSetting> ServiceSettings { get; set; }
    }
}
