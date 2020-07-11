using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using waSales.Data;
using waSales.Entities.Tipification;
using waSales.Web.Models.Tipification.ExchangeCurrency;

namespace waSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeCurrenciesController : ControllerBase
    {
        private readonly DbContextApp _context;

        public ExchangeCurrenciesController(DbContextApp context)
        {
            _context = context;
        }
       
        // GET: api/ExchangeCurrencies/5
        [HttpGet("{companyId}")]
        public IEnumerable<ExchangeCurrencyViewModel> GetExchangeCurrencies([FromRoute] int companyId)
        {
            List< ExchangeCurrency> list = _context.ExchangeCurrencies.Where(x => x.Enabled == true && x.CompanyId == companyId).ToList();
            List<ExchangeCurrencyViewModel> list2 = new List<ExchangeCurrencyViewModel>();
            foreach (var item in list)
            {
                ExchangeCurrencyViewModel model = new ExchangeCurrencyViewModel
                {
                    CompanyId= item.CompanyId,
                    DateEnd = item.DateEnd,
                    Description = item.Description,
                    Enabled = item.Enabled,
                    Id = item.Id,
                    Quote=item.Quote
                };
                list2.Add(model);
            }

            return list2;

        }

        // POST: api/ExchangeCurrencies/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateExchangeCurrencyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ExchangeCurrency modelo = new ExchangeCurrency
            {
                Description = model.Description,
                CompanyId = model.CompanyId,
                Quote = model.Quote,
                Enabled = true
            };


            _context.ExchangeCurrencies.Add(modelo);
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


        // PUT: api/ExchangeCurrencies/Update/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateExchangeCurrencyViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.ExchangeCurrencies.FirstOrDefaultAsync(x => x.Id == model.Id);

            modelo.Description = model.Description;
            modelo.DateEnd = model.DateEnd;
            modelo.Quote = model.Quote;



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


        // PUT: api/ExchangeCurrencies/Delete/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteExchangeCurrencyViewModel model)
        {


            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.ExchangeCurrencies.FirstOrDefaultAsync(x => x.Id == model.Id);

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
