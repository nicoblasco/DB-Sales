using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using waSales.Data;
using waSales.Entities.Tipification;
using waSales.Web.Models.Reusable.Combo;
using waSales.Web.Models.Reusable.Common;

namespace waSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly DbContextApp _context;

        public CountriesController(DbContextApp context)
        {
            _context = context;
        }

        // GET: api/Countries/5
        [HttpGet("{companyId}")]
        public IEnumerable<Country> GetCountries([FromRoute] int companyId)
        {
            return _context.Countries.Where(x => x.Enabled == true && x.CompanyId == companyId);
        }


        // GET: api/Countries/GetFull/5
        [HttpGet("[action]/{companyId}")]
        public IEnumerable<ComboViewModel> GetFull([FromRoute] int companyId)
        {
            //  List<City> cities = _context.Cities.Where(x => x.Enabled).Include(x => x.State).ThenInclude(x => x.Country.CompanyId == companyId).ToList();

            List<Country> countries = _context.Countries.Where(x => x.CompanyId == companyId && x.Enabled && x.States.Any(y=>y.Enabled && y.Cities.Any(c=>c.Enabled))  ).Include(y=>y.States).ThenInclude(x=>x.Cities).ToList();


            List<ComboViewModel> list = new List<ComboViewModel>();

            foreach (var country in countries.OrderBy(x=>x.Description))
            {
                ComboViewModel comboCountry = new ComboViewModel
                {
                    Value = country.Id,
                    Label = country.Description,
                    Children = new List<ComboViewModel>()
                };

                foreach (var state  in country.States.OrderBy(x => x.Description))
                {
                    if (state.Enabled)
                    {
                        ComboViewModel comboState = new ComboViewModel
                        {
                            Value = state.Id,
                            Label = state.Description,
                            Children = new List<ComboViewModel>()
                        };

                        foreach (var city in state.Cities.OrderBy(x => x.Description))
                        {
                            if (city.Enabled) 
                            {
                                ComboViewModel comboCity = new ComboViewModel
                                {
                                    Value = city.Id,
                                    Label = city.Description
                                };
                                comboState.Children.Add(comboCity);
                            }

                        }

                        comboCountry.Children.Add(comboState);
                    }

                }

                list.Add(comboCountry);
            }



            return list;
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

        // POST: api/Countries/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Country modelo = new Country
            {
                Description = model.Description,
                CompanyId = model.CompanyId,
                Enabled = true
            };


            _context.Countries.Add(modelo);
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


        // PUT: api/Countries/Update/5
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

            var modelo = await _context.Countries.FirstOrDefaultAsync(x => x.Id == model.Id);

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


        // PUT: api/Countries/Delete/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteViewModel model)
        {


            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.Countries.FirstOrDefaultAsync(x => x.Id == model.Id);

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
