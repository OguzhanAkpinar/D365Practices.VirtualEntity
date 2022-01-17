using VirtualEntityODataSource.Data.Entities.Base;

namespace VirtualEntityODataSource.Data.Entities
{
    public class DrivingLicenceType : EntityBase
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public string MinimumAge { get; set; }
        public string Notes { get; set; }
    }
}
