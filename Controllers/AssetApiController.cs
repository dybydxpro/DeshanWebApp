using DeshanWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeshanWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetApiController : ControllerBase
    {
        private readonly AppDatabaseContexts _database;
        public AssetApiController(AppDatabaseContexts database)
        {
            _database = database;
        }

        [HttpGet("location")]
        public async Task<ActionResult<List<AppDatabaseContexts>>> Get(string location)
        {
            var obj =_database.Carts.ToList();
            
            foreach (var item in obj)
            {
                var data = new Transfer();
                data.Name = item.Name;
                data.ISBN = item.ISBN;
                data.Location = location;
                await _database.SaveChangesAsync();

                var del =await _database.Carts.FindAsync(data.Id);
                _database.Carts.Remove(del);
                await _database.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
