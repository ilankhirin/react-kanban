using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigins")]
    public class BoardController : ControllerBase
    {
        [HttpPut]
        public void Put([FromBody] Board value)
        {
            System.Console.WriteLine(value);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            System.Console.WriteLine(id);
        }
    }
}
