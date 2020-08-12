using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_API_DAPPER.IServices;
using MVC_API_DAPPER.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_API_DAPPER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private IPositionService _oPositionService;
        public PositionController(IPositionService oPositionService)
        {
            _oPositionService = oPositionService;
        }

        // GET: api/Position
        [HttpGet]
        public IEnumerable<Position> Get()
        {
            return _oPositionService.Gets();
        }

        // GET api/Position/5
        [HttpGet("{id}")]
        public Position Get(int id)
        {
            return _oPositionService.Get(id);
        }
        
        /* 
        *{"name": "Richard",
        *"roll": "Director",
        *"message": "Hola Mundo"
        *}
        */

        // POST api/Position
        [HttpPost]
        public Position Post([FromBody] Position oPosition)
        {
            if (ModelState.IsValid) return _oPositionService.Save(oPosition);
            return null;
        }

        // PUT api/Position/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Position/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _oPositionService.Delete(id);
        }
    }
}
