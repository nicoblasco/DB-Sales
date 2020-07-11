using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using waSales.Data;
using waSales.Entities.Tipification;
using waSales.Web.Models.Reusable.Cascade;

namespace waSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly DbContextApp _context;

        public CitiesController(DbContextApp context)
        {
            _context = context;
        }

        // GET: api/Cities
        [HttpGet("{companyId}")]
        public IEnumerable<IndexCascadeViewModel> GetCities([FromRoute] int companyId)
        {

            List<City> modelo = _context.Cities.Where(x => x.Enabled == true && x.State.Country.CompanyId == companyId).Include(x => x.State).ThenInclude(x=>x.Country).ToList();
            List<IndexCascadeViewModel> list = new List<IndexCascadeViewModel>();
            foreach (var item in modelo)
            {
                IndexCascadeViewModel indexViewModel = new IndexCascadeViewModel
                {
                    ParentId = item.StateId,
                    GrandParent = item.State.Country.Description,
                    GrandParentId = item.State.CountryId,
                    Parent = item.State?.Description,
                    Description = item.Description,
                    Enabled = item.Enabled,
                    Id = item.Id

                };
                list.Add(indexViewModel);
            }

            return list;
        }

        // PUT: api/Cities/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCascadeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            City modelo = new City
            {
                Description = model.Description,
                Enabled = true,
                StateId = model.ParentId,                

            };


            _context.Cities.Add(modelo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Cities/Update
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCascadeViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.Cities.FirstOrDefaultAsync(x => x.Id == model.Id);

            modelo.Description = model.Description;
            modelo.StateId = model.ParentId;


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


        // DELETE: api/Cities/Delete/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteCascadeViewModel model)
        {


            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.Cities.FirstOrDefaultAsync(x => x.Id == model.Id);

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
