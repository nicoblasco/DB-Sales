using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using waSales.Data;
using waSales.Entities.Provider;
using waSales.Web.Models.Provider;

namespace waSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly DbContextApp _context;

        public ProvidersController(DbContextApp context)
        {
            _context = context;
        }

        // GET: api/Providers/5
        [HttpGet("{companyId}")]
        public IEnumerable<IndexProviderViewModel> GetProviders([FromRoute] int companyId)
        {
            List<Provider> providers = _context.Providers.Where(x => x.Enabled == true && x.CompanyId == companyId).ToList();
            List<IndexProviderViewModel> list = new List<IndexProviderViewModel>();
            foreach (var item in providers)
            {
                IndexProviderViewModel model = new IndexProviderViewModel
                {
                    Address = item.Address,
                    CityId = item.CityId,
                    DateInitial = item.DateInitial,
                    Documento = item.Documento,
                    DocumentTypeId= item.DocumentTypeId,
                    Email=item.Email,
                    Enabled = item.Enabled,
                    Favorite = item.Favorite,
                    Id= item.Id,
                    Observation = item.Observation,
                    Phone = item.Phone,
                    RazonSocial = item.RazonSocial,
                    WebSite = item.WebSite
                };
                list.Add(model);
            }

            return list;
        }


        // POST: api/Providers/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProviderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Provider modelo = new Provider
            {                
                CompanyId = model.CompanyId,
                Enabled = true,
                Address = model.Address,
                CityId = model.CityId,
                WebSite= model.WebSite,
                RazonSocial= model.RazonSocial,
                Phone= model.Phone,
                DateInitial= DateTime.Now,
                Documento = model.Documento,
                DocumentTypeId = model.DocumentTypeId,
                Email=model.Email,
                Favorite = model.Favorite,
                Observation= model.Observation
            };


            _context.Providers.Add(modelo);
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


        // PUT: api/Providers/Update/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProviderViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.Providers.FirstOrDefaultAsync(x => x.Id == model.Id);

            modelo.Address = model.Address;
            modelo.CityId = model.CityId;
            modelo.Documento = model.Documento;
            modelo.DocumentTypeId = model.DocumentTypeId;
            modelo.Email = model.Email;
            modelo.Favorite = model.Favorite;
            modelo.Observation = model.Observation;
            modelo.Phone = model.Phone;
            modelo.RazonSocial = model.Phone;
            modelo.WebSite = model.WebSite;



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


        // PUT: api/Providers/Delete/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteProviderViewModel model)
        {


            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.Providers.FirstOrDefaultAsync(x => x.Id == model.Id);

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
