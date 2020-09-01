using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using waSales.Data;
using waSales.Entities.Customer;
using waSales.Web.Models.Customer;

namespace waSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DbContextApp _context;
        private readonly IConfiguration _config;

        public CustomersController(DbContextApp context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Customers/5
        [HttpGet("{companyId}")]
        public IEnumerable<IndexCustomerViewModel> GetCustomers ([FromRoute] int companyId)
        {
            List<Customer> providers = _context.Customers.Where(x => x.Enabled == true && x.CompanyId == companyId).Include(x => x.Cities).ToList();
            List<IndexCustomerViewModel> list = new List<IndexCustomerViewModel>();
            foreach (var item in providers)
            {
                IndexCustomerViewModel model = new IndexCustomerViewModel
                {
                    Address = item.Address,
                    CountryId = item.CountryId,
                    StateId = item.StateId,
                    CityId = item.CityId,
                    City = item.Cities?.Description,
                    DateInitial = item.DateInitial,
                    Documento = item.Documento,
                    DocumentTypeId = item.DocumentTypeId,
                    Email = item.Email,
                    Enabled = item.Enabled,
                    Favorite = item.Favorite,
                    Id = item.Id,
                    Observation = item.Observation,
                    Phone = item.Phone,
                    Names = item.Names,
                    PriceListId = item.PriceListId
                };

                if (!string.IsNullOrEmpty(item.Logo))
                {
                    byte[] imageArray = System.IO.File.ReadAllBytes(@item.Logo);
                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                    model.Logo = "data:image/png;base64," + base64ImageRepresentation;
                }

                list.Add(model);
            }

            return list.OrderBy(x => x.Names);
        }


        // POST: api/Customers/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateCustomerViewModel model)
        {
            string strRuta = _config["CustomerAvatar"];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer modelo = new Customer
            {
                CompanyId = model.CompanyId,
                Enabled = true,
                Address = model.Address,
                CountryId = model.CountryId,
                StateId = model.StateId,
                CityId = model.CityId,
                Names = model.Names,
                Phone = model.Phone,
                DateInitial = DateTime.Now,
                Documento = model.Documento,
                DocumentTypeId = model.DocumentTypeId,
                Email = model.Email,
                Favorite = model.Favorite,
                Observation = model.Observation,
                PriceListId = model.PriceListId
            };


            _context.Customers.Add(modelo);
            try
            {
                await _context.SaveChangesAsync();


                //Guardo el avatar
                if (modelo.Id > 0)
                {
                    if (!(string.IsNullOrEmpty(model.LogoName)) && (!string.IsNullOrEmpty(model.Logo)))
                    {
                        strRuta = strRuta + "//" + modelo.Id.ToString() + "//" + model.LogoName;
                        System.IO.FileInfo file = new System.IO.FileInfo(strRuta);
                        file.Directory.Create();
                        System.IO.File.WriteAllBytes(strRuta, Convert.FromBase64String(model.Logo.Substring(model.Logo.LastIndexOf(',') + 1)));
                        modelo.Logo = strRuta;
                    }
                }

                _context.Entry(modelo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }


        // PUT: api/Customers/Update/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerViewModel model)
        {

            string strRuta = _config["CustomerAvatar"];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.Customers.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (modelo == null)
                return BadRequest("Cliente inexistente");

            modelo.Address = model.Address;
            modelo.CountryId = model.CountryId;
            modelo.StateId = model.StateId;
            modelo.CityId = model.CityId;
            modelo.Documento = model.Documento;
            modelo.DocumentTypeId = model.DocumentTypeId;
            modelo.Email = model.Email;
            modelo.Favorite = model.Favorite;
            modelo.Observation = model.Observation;
            modelo.Phone = model.Phone;
            modelo.Names = model.Names;
            modelo.PriceListId = model.PriceListId;

            ////Guardo el avatar
            if (!(string.IsNullOrEmpty(model.LogoName)) && (!string.IsNullOrEmpty(model.Logo)))
            {
                strRuta = strRuta + "//" + modelo.Id.ToString() + "//" + model.LogoName;
                System.IO.FileInfo file = new System.IO.FileInfo(strRuta);
                file.Directory.Create();
                System.IO.File.WriteAllBytes(strRuta, Convert.FromBase64String(model.Logo.Substring(model.Logo.LastIndexOf(',') + 1)));
                modelo.Logo = strRuta;
            }


            _context.Entry(modelo).State = EntityState.Modified;

            if (modelo == null)
            {
                return NotFound();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //Guardar Exception
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        // PUT: api/Customers/Delete/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerViewModel model)
        {


            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.Customers.FirstOrDefaultAsync(x => x.Id == model.Id);

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
