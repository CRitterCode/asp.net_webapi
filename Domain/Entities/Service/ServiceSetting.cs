using Domain.Entities.Reservation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Service
{
    [Table(nameof(ServiceSetting))]
    public class ServiceSetting : EntityBase
    {
        public uint ServiceTypeId { get; set; }
        public uint BuisnessId { get; set; }
        public uint Amount { get; set; } = 1;

        //Relation
        public ServiceType Service { get; set; }
        public uint? ParentServiceSetting { get; set; }
        public Business Buisness { get; set; }

        public List<ServiceSetting> ChildServiceSettings { get; set; }

    }
}
