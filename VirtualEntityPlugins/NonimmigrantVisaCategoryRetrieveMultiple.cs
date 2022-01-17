using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using System;
using VirtualEntityPlugins.Business.Helpers;
using VirtualEntityPlugins.Model.OData;
using VirtualEntityPlugins.Model.OData.Base;

namespace VirtualEntityPlugins
{
    public class NonimmigrantVisaCategoryRetrieveMultiple : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            string content = ODataHelper.Call("<BaseUrl>/odata/NonimmigrantVisaCategories", "GET");

            ODataResult<NonimmigrantVisaCategory> odataResult = JsonConvert.DeserializeObject<ODataResult<NonimmigrantVisaCategory>>(content);
            EntityCollection collection = new EntityCollection();
            Entity entity = null;
            foreach (var nonimmigrantvisacategory in odataResult.value)
            {
                entity = new Entity("new_nonimmigrantvisacategory");
                entity["new_nonimmigrantvisacategoryid"] = nonimmigrantvisacategory.Id;
                entity["new_name"] = nonimmigrantvisacategory.VisaCategory;
                entity["new_purposeoftravel"] = nonimmigrantvisacategory.PurposeOfTravel;
                entity["new_beforeapplyingforvisa"] = nonimmigrantvisacategory.BeforeApplyingForVisa;
                collection.Entities.AddRange(entity);
            }
            context.OutputParameters["BusinessEntityCollection"] = collection;
        }
    }
}
