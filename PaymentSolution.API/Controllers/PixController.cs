using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentSolution.Application.Factorys;
using PaymentSolution.Application.Interfaces.Services;
using PaymentSolution.Shared.Dtos.Pix;
using PaymentSolution.Shared.Enums;

namespace PaymentSolution.API.Controllers
{
    [Route("api/pix/{serviceType}")]
    [ApiController]
    [AllowAnonymous]
    public class PixController : ControllerBase
    {
        private readonly PixServiceFactory _pixServiceFactory;
        public PixController(PixServiceFactory pixServiceFactory)
        {
            _pixServiceFactory = pixServiceFactory;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(PaymentServiceType serviceType, [FromBody] CreatePixDto createPixDto)
        {
            IPixService pixService = _pixServiceFactory.Create(serviceType);
            var resp = await pixService.CreateAsync(createPixDto);
            return resp.Success ? StatusCode(201, resp) : StatusCode(400, resp);
        }

        [HttpGet]
        public async Task<IActionResult> Get(PaymentServiceType serviceType, string id, bool includeQrCode = false, int height = 186, int width = 168)
        {
            IPixService pixService = _pixServiceFactory.Create(serviceType);
            var resp = await pixService.GetAsync(id, includeQrCode, height, width);
            return resp.Success ? Ok(resp) : BadRequest(resp);
        }
    }
}
