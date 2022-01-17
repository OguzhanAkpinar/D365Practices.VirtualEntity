using System;

namespace VirtualEntityPlugins.Model.OData
{
    public class NonimmigrantVisaCategory
    {
        public Guid Id { get; set; }
        public string PurposeOfTravel { get; set; }
        public string VisaCategory { get; set; }
        public string BeforeApplyingForVisa { get; set; }
    }
}
