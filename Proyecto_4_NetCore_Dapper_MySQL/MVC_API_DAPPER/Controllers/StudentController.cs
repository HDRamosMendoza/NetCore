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
    public class StudentController : ControllerBase
    {
        private IStudentService _oStudentService;
        public StudentController(IStudentService oStudentService)
        {
            _oStudentService = oStudentService;
        }

        // GET: api/Student
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _oStudentService.Gets();
        }

        // GET api/Student/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _oStudentService.Get(id);
        }

        /* 
        *{"name": "Richard",
        *"roll": "Director",
        *"message": "Hola Mundo"
        *}
        */

        //POST api/Student
        [HttpPost]
        public Student Post([FromBody] Student oStudent)
        {
            if (ModelState.IsValid) return _oStudentService.Save(oStudent);
            return null;
        }

        // PUT api/Student/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Student/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return _oStudentService.Delete(id);
        }
    }
}
