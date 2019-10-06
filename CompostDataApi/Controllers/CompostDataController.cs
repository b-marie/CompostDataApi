using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompostDataApi.Models;
using CompostDataApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompostDataApi.Controllers
{
    [Route("")]
    [ApiController]
    public class CompostDataController : ControllerBase
    {
        ProjectService _projectService;
        public CompostDataController(ProjectService projectService)
        {
            _projectService = projectService;
        }
        // GET api/compost
        [HttpGet]
        public async Task<Project> GetProject()
        {
            Guid id = Guid.NewGuid();
            return await _projectService.GetProject(id);
        }

        [HttpGet("data/{results}")]
        public async Task<IEnumerable<CompostData>> GetCompostData(int results)
        {
            return await _projectService.GetCompostData(results);
        }
    }
}
