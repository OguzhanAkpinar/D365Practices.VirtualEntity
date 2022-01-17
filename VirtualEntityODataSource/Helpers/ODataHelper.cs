using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using VirtualEntityODataSource.Data.Entities;

namespace VirtualEntityODataSource.Helpers
{
    public static class ODataHelper
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<DrivingLicenceType>("DrivingLicenceTypes");
            builder.EntitySet<NonimmigrantVisaCategory>("NonimmigrantVisaCategories");
            return builder.GetEdmModel();
        }
    }
}
