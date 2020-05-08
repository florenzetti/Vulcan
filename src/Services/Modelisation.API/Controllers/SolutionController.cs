using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modelisation.API.Application.Models;
using Modelisation.Domain.SolutionAggregate;
using Modelisation.Infrastructure;

namespace Modelisation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        private readonly ModelisationContext _modelisationContext;
        // GET: api/Solution
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Solution/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Solution
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SolutionViewModel viewModel)
        {
            Solution item = new Solution(string.Empty, viewModel.Name);
            _modelisationContext.Add(item);

            await _modelisationContext.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Solution/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
