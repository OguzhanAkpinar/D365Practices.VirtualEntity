using Microsoft.Xrm.Sdk;
using System;
using VirtualEntityPlugins.Business.Helpers;

namespace VirtualEntityPlugins
{
    public class NonimmigrantVisaCategoryDelete : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            EntityReference entity = ((EntityReference)context.InputParameters["Target"]);
            string content = ODataHelper.Call("<BaseUrl>/odata/NonimmigrantVisaCategories/" + Convert.ToString(entity.Id), "DELETE");
        }
    }
}
