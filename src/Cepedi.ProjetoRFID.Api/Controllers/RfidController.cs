using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.ProjetoRFID.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RfidController : ControllerBase
    {
        private readonly RfidService _rfidService;

        public RfidController(RfidService rfidService)
        {
            _rfidService = rfidService;
        }

        [HttpPost("process-rfid")]
        public async Task<IActionResult> ProcessRfid()
        {
            var filePath = "src/Cepedi.ProjetoRFID.Data/DataBase/reading.json";
            await _rfidService.ProcessRfidJsonAsync(filePath);
            return Ok();
        }
    }

}
