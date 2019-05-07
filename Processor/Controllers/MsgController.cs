using System.Collections.Generic;
using Common.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Processor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MsgController : ControllerBase
    {
        private IReadWriteStore _readWriteStoreService;

        public MsgController(IReadWriteStore readWriteStoreService)
        {
            _readWriteStoreService = readWriteStoreService;
        }

        // GET api/msg
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/msg/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
