using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace MVC_API_DAPPER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingController : ControllerBase
    {
		// MYSQL
		private string _connection = @"Server=localhost; Database=DemoNetCore21DB; Uid=root; Pwd=root;";

		[HttpGet]
		public IActionResult Get()
		{
			//List<Models.Thing> lst = new List<Models.Thing>();
			// Creamos un IEnumerable para se meta automatizamente.
			IEnumerable<Models.Thing> lst = null;
			using (var db = new MySqlConnection(_connection))
			{
				var sql = "SELECT id,name, description from Thing";
				//return Ok("HolaMundo"); 
				lst = db.Query<Models.Thing>(sql);
			}
			return Ok(lst);
		}

		[HttpPost]
		public IActionResult Insert(Models.Thing model)
        {
			int result = 0;
			using (var db = new MySqlConnection(_connection))
			{
				//los @ evita lo sqlInjection
				var sql = "insert into Thing(name, description)"+
					" values(@name, @description)";
				//return Ok("HolaMundo"); 
				result = db.Execute(sql, model);
				/* POR POSTMAN
					{
						"name": "CARRO",
						"description": "Una cosa que se mueva"
					}
				 */
			}
			return Ok(result);
		}

		[HttpPut]
		public IActionResult Edit(Models.Thing model)
		{
			int result = 0;
			using (var db = new MySqlConnection(_connection))
			{
				//los @ evita lo sqlInjection
				var sql = "UPDATE Thing set name=@name, description=@description" +
					" where id=@id";
				result = db.Execute(sql, model);
				/* POR POSTMAN
					{
						"id": 1,
						"name": "CARRO",
						"description": "Bebida que te manta"
					}
				 */
			}
			return Ok(result);
		}

		[HttpDelete]
		public IActionResult Delete(Models.Thing model)
		{
			int result = 0;
			using (var db = new MySqlConnection(_connection))
			{
				//los @ evita lo sqlInjection
				var sql = "DELETE from Thing where id=@id";
				result = db.Execute(sql, model);
				/* POR POSTMAN
					{
						"id": 1
					}
				 */
			}
			return Ok(result);
		}
	}
}
