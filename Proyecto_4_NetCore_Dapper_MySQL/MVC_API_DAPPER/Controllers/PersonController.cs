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
    public class PersonController : ControllerBase
    {
        private IPersonService _oPersonService;
        public PersonController(IPersonService oPersonService)
        {
            _oPersonService = oPersonService;
        }

        // GET: api/Person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _oPersonService.Gets();
        }

        // GET api/Person/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _oPersonService.Get(id);
        }

        /* 
        *{"name": "Richard",
        *"roll": "Director",
        *"message": "Hola Mundo"
        *}
        */

        // POST api/Person
        [HttpPost]
        public Person Post([FromBody] Person oPerson)
        {
            if (ModelState.IsValid) return _oPersonService.Save(oPerson);
            return null;
        }

        // PUT api/Person/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Person/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _oPersonService.Delete(id);
        }
    }
}
