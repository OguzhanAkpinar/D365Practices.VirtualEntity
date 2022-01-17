using VirtualEntityODataSource.Data.Entities.Base;

namespace VirtualEntityODataSource.Data.Entities
{
    public class NonimmigrantVisaCategory : EntityBase
    {
        public string PurposeOfTravel { get; set; }
        public string VisaCategory { get; set; }
        public string BeforeApplyingForVisa { get; set; }
    }
}
