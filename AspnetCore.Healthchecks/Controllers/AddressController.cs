using AspnetCore.Healthchecks.Metrics.ApplicationServices.Dtos;
using AspnetCore.Healthchecks.Metrics.ApplicationServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetCore.Healthchecks.Metrics.Api.Controllers
{
    [Route("v1/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressQueryDto>>> ListAddressesAsync([FromServices] IAddressAplicationService _service)
        {
            var addresses = await _service.ListAddressesAsync();

            return Ok(addresses);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<AddressQueryDto>>> SaveAddressAsync([FromServices] IAddressAplicationService _service, [FromBody] AddressDto addressDto)
        {
            var result = await _service.SaveAddressAsync(addressDto);

            return Ok(result);
        }
    }
}
