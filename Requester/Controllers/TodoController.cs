using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Requester.Model;
using Requester.Port;

namespace Requester.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private IAmMsgStorageForRequesterToReadAndWriteFrom _msgStoreService;

        public TodoController(IAmMsgStorageForRequesterToReadAndWriteFrom msgStoreService)
        {
            _msgStoreService = msgStoreService;
        }

        // GET api/todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> Get()
        {
            using (var client = new HttpClient())
            {
                // Put msg on queue for Rabbit
                //var jsonResponse = await client.GetStringAsync("http://localhost:5002/api/msg");
                //var response = JsonConvert.DeserializeObject<IEnumerable<Message>>(jsonResponse);

                //_msgStoreService.ReadMsgFromStore();
                return Ok("123");
            }
        }

        // GET api/todo/5
        [HttpGet("{msgId}")]
        public async Task<ActionResult<Message>> Get(int msgId)
        {
            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync($"http://localhost:5002/api/msg/{msgId}");
                var content = await httpResponse.Content.ReadAsStringAsync();
                return Ok(content);
            }
        }

        // POST api/todo
        [HttpPost]
        public void Post([FromBody] Message msg)
        {
            _msgStoreService.WriteMsgToStore(msg);
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
