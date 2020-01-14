using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatinApp.api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatinApp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext dataContext)
        {
            this._context = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await this._context.Values.ToListAsync();
            return Ok(values);
        }

[AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await this._context.Values.FirstOrDefaultAsync(p => p.ID == id);
            return Ok(value);
        }

         [HttpPost]
         public void Post([FromBody] string value){

         }


    }
}