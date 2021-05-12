using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TestePraticoWevo.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class UserController:ControllerBase {
        public UserController(AppDb db) {
            Db = db;
        }

        // GET api/user
        [HttpGet]
        public async Task<IActionResult> GetLatest() {
            await Db.Connection.OpenAsync();
            var query = new UserQuery(Db);
            var result = await query.LatestPostsAsync();
            return new OkObjectResult(result);
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id) {
            await Db.Connection.OpenAsync();
            var query = new UserQuery(Db);
            var result = await query.FindOneAsync(id);
            if(result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User body) {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] User body) {
            await Db.Connection.OpenAsync();
            var query = new UserQuery(Db);
            var result = await query.FindOneAsync(id);
            if(result is null)
                return new NotFoundResult();
            result.Name = body.Name;
            result.Cpf = body.Cpf;
            result.Email = body.Email;
            result.Phone = body.Phone;
            result.Gender = body.Gender;
            result.BirthDate = body.BirthDate;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id) {
            await Db.Connection.OpenAsync();
            var query = new UserQuery(Db);
            var result = await query.FindOneAsync(id);
            if(result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE api/user
        [HttpDelete]
        public async Task<IActionResult> DeleteAll() {
            await Db.Connection.OpenAsync();
            var query = new UserQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        public AppDb Db { get; }
	}
}
