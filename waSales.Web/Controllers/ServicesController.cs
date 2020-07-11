using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using waSales.Data;
using waSales.Entities.Tipification;
using waSales.Web.Models.Reusable.Common;

namespace waSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly DbContextApp _context;

        public ServicesController(DbContextApp context)
        {
            _context = context;
        }

        // GET: api/Services/5
        [HttpGet("{companyId}")]
        public IEnumerable<Service> GetServices([FromRoute] int companyId)
        {
            return _context.Services.Where(x => x.Enabled == true && x.CompanyId == companyId);
        }

        //// GET: api/PriceList/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPriceList([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var modelo = await _context.SalesStates.FindAsync(id);



        //    if (modelo == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(modelo);
        //}

        // POST: api/Services/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Service modelo = new Service
            {
                Description = model.Description,
                CompanyId = model.CompanyId,
                Enabled = true
            };


            _context.Services.Add(modelo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {

                return BadRequest();
            }

            return Ok();
        }


        // PUT: api/Services/Update/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.Services.FirstOrDefaultAsync(x => x.Id == model.Id);

            modelo.Description = model.Description;



            _context.Entry(modelo).State = EntityState.Modified;

            if (modelo == null)
            {
                return NotFound();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Guardar Exception
                return BadRequest();
            }

            return Ok();
        }


        // PUT: api/Services/Delete/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteViewModel model)
        {


            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.Services.FirstOrDefaultAsync(x => x.Id == model.Id);

            modelo.Enabled = false;



            _context.Entry(modelo).State = EntityState.Modified;

            if (modelo == null)
            {
                return NotFound();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Guardar Exception
                return BadRequest();
            }

            return Ok();
        }
    }
}
