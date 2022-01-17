using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System;
using System.Threading.Tasks;
using VirtualEntityODataSource.Data.Entities;
using VirtualEntityODataSource.Repositories;

namespace VirtualEntityODataSource.Controllers
{
    public class NonimmigrantVisaCategoryController : ODataController
    {
        private readonly IODataRepository<NonimmigrantVisaCategory> _IODataRepository;

        public NonimmigrantVisaCategoryController(IODataRepository<NonimmigrantVisaCategory> _IODataRepository)
        {
            this._IODataRepository = _IODataRepository;
        }

        [EnableQuery]
        [HttpGet("odata/NonimmigrantVisaCategories")]
        public async Task<IActionResult> Get()
        {
            return Ok(await this._IODataRepository.Get());
        }

        [HttpDelete("odata/NonimmigrantVisaCategories/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            bool result =await  this._IODataRepository.Delete(Id);
            return result ? Ok() : BadRequest();
        }
    }
}
