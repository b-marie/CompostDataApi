using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompostDataApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompostDataApi.Controllers
{
    [Route("api/compost")]
    [ApiController]
    public class CompostDataController : ControllerBase
    {
        // GET api/compost/guid
        [HttpGet("{id}")]
        public ActionResult<Project> Get(Guid id)
        {
            return new Project();
        }

        // POST api/compost
        [HttpPost]
        public void Post()
        {
        }
    }
}
