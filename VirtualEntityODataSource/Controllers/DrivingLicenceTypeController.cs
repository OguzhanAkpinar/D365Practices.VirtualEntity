using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Threading.Tasks;
using VirtualEntityODataSource.Data.Entities;
using VirtualEntityODataSource.Repositories;

namespace VirtualEntityODataSource.Controllers
{
    public class DrivingLicenceTypeController : ODataController
    {
        private readonly IODataRepository<DrivingLicenceType> _IODataRepository;

        public DrivingLicenceTypeController(IODataRepository<DrivingLicenceType> _IODataRepository)
        {
            this._IODataRepository = _IODataRepository;
        }

        [EnableQuery]
        [HttpGet("odata/DrivingLicenceTypes")]
        public async Task<IActionResult> Get()
        {
            return Ok(await this._IODataRepository.Get());
        }
    }
}
