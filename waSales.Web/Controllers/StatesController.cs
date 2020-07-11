using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using waSales.Data;
using waSales.Entities.Tipification;
using waSales.Web.Models.Reusable.Dependent;

namespace waSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly DbContextApp _context;

        public StatesController(DbContextApp context)
        {
            _context = context;
        }

        // GET: api/States/1
        [HttpGet("{companyId}")]
        public IEnumerable<IndexDependentViewModel> GetStates([FromRoute] int companyId)
        {

            List<State> modelo = _context.States.Where(x => x.Enabled == true && x.Country.CompanyId == companyId).Include(x => x.Country).ToList();
            List<IndexDependentViewModel> list = new List<IndexDependentViewModel>();
            foreach (var item in modelo)
            {
                IndexDependentViewModel indexViewModel = new IndexDependentViewModel
                {
                    ParentId = item.CountryId,
                    Parent = item.Country?.Description,
                    Description = item.Description,
                    Enabled = item.Enabled,
                    Id = item.Id

                };
                list.Add(indexViewModel);
            }

            return list;
        }

        // GET: api/States/GetByCountry/5
        [HttpGet("[action]/{countryId}")]
        public IEnumerable<IndexDependentViewModel> GetByCountry([FromRoute] int countryId)
        {

            List<State> modelo = _context.States.Where(x => x.Enabled == true && x.CountryId == countryId).Include(x => x.Country).ToList();
            List<IndexDependentViewModel> list = new List<IndexDependentViewModel>();
            foreach (var item in modelo)
            {
                IndexDependentViewModel indexViewModel = new IndexDependentViewModel
                {
                    ParentId = item.CountryId,
                    Parent = item.Country?.Description,
                    Description = item.Description,
                    Enabled = item.Enabled,
                    Id = item.Id

                };
                list.Add(indexViewModel);
            }

            return list;
        }

        // PUT: api/States/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateDependentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            State modelo = new State
            {
                Description = model.Description,
                Enabled = true,
                CountryId = model.ParentId
            };


            _context.States.Add(modelo);
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

        // POST: api/States/Update
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateDependentViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.States.FirstOrDefaultAsync(x => x.Id == model.Id);

            modelo.Description = model.Description;
            modelo.CountryId = model.ParentId;


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


        // DELETE: api/SubCategories/Delete/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteDependentViewModel model)
        {


            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.States.FirstOrDefaultAsync(x => x.Id == model.Id);

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
