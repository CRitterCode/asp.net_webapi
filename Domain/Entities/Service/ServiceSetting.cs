namespace Domain.Entities.Service
{
    public class ServiceSetting : EntityBase
    {
        public int Amount { get; set; } = 1;

        //Relation
        public ServiceType Service { get; set; }
        public int? ParentServiceSetting { get; set; }
        public int BuisnessId { get; set; }

        public List<ServiceSetting> ChildServiceSettings { get; set; } = new();

    }
}
