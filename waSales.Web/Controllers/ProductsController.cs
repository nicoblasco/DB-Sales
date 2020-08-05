using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using waSales.Data;
using waSales.Entities.Product;
using waSales.Web.Models.Product;

namespace waSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DbContextApp _context;
        private readonly IConfiguration _config;

        public ProductsController(DbContextApp context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Products/5
        [HttpGet("{companyId}")]
        public IEnumerable<IndexProductViewModel> GetProviders([FromRoute] int companyId)
        {
            List<Product> products  = _context.Products.Where(x => x.Enabled && x.CompanyId == companyId).Include(x => x.Category).Include(x=>x.SubCategory).Include(x=>x.Brand).Include(x=>x.Location).Include(x=>x.ExchangeCurrency).ToList();
            List<IndexProductViewModel> list = new List<IndexProductViewModel>();
            foreach (var item in products)
            {
                IndexProductViewModel model = new IndexProductViewModel
                {
                    Id = item.Id,
                    Awaiting = item.Awaiting,
                    Brand = item.Brand?.Description,
                    BrandId= item.BrandId,
                    Category = item.Category.Description,
                    CategoryId = item.CategoryId,
                    Codigo = item.Codigo,
                    Cost = item.Cost,
                    DateInitial = item.DateInitial.ToString("dd/MM/yyyy"),
                    Description = item.Description,
                    Discount = item.Discount,
                    ExchangeCurrency = item.ExchangeCurrency.Description,
                    ExchangeCurrencyId = item.ExchangeCurrencyId,
                    Gain= item.Gain,
                    InStock = item.InStock,
                    Location = item.Location.Description,
                    LocationId = item.LocationId,
                    Name = item.Name,
                    NameShort=item.NameShort,
                    OutOfStock = item.OutOfStock,
                    Price = item.Price,
                    Stock = item.Stock,
                    StockMin = item.StockMin,
                    SubCategory = item.SubCategory.Description,
                    SubCategoryId = item.SubCategoryId,
                    CheckStock = item.CheckStock
                };

                if (!string.IsNullOrEmpty(item.Logo))
                {
                    byte[] imageArray = System.IO.File.ReadAllBytes(@item.Logo);
                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                    model.Logo = "data:image/png;base64," + base64ImageRepresentation;
                }

                list.Add(model);
            }

            return list.OrderBy(x => x.Name);
        }


        // POST: api/Products/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateProductViewModel model)
        {
            string strRuta = _config["ProductAvatar"];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product modelo = new Product
            {
                Awaiting = model.Awaiting ?? false,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                Codigo = model.Codigo.Trim(),
                CompanyId = model.CompanyId,
                Cost = model.Cost,
                DateInitial = DateTime.Now,
                Description = model.Description,
                Discount = model.Discount??0,
                Enabled = true,
                ExchangeCurrencyId = model.ExchangeCurrencyId,
                Gain = model.Gain,
                InStock = model.InStock ?? false,
                LocationId = model.LocationId,
                Name = model.Name.Trim(),
                NameShort = model.NameShort.Trim(),
                OutOfStock = model.OutOfStock??false,
                Price = model.Price??0,
                Stock = model.Stock,
                StockMin = model.StockMin,
                SubCategoryId = model.SubCategoryId,
                CheckStock = model.CheckStock??false
            };


            _context.Products.Add(modelo);
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


        // PUT: api/Products/Update/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateProductViewModel model)
        {

            string strRuta = _config["ProductAvatar"];

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.Products.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (modelo == null)
                return BadRequest("Producto inexistente");

            modelo.Awaiting = model.Awaiting;
            modelo.BrandId = model.BrandId;
            modelo.CategoryId = model.CategoryId;
            modelo.CheckStock = model.CheckStock;
            modelo.Codigo = model.Codigo;
            modelo.Cost = model.Cost;
            modelo.Description = model.Description;
            modelo.Discount = model.Discount;
            modelo.ExchangeCurrencyId = model.ExchangeCurrencyId;
            modelo.Gain = model.Gain;
            modelo.InStock = model.InStock;
            modelo.LocationId = model.LocationId;
            modelo.Name = model.Name;
            modelo.NameShort = model.NameShort;
            modelo.OutOfStock = model.OutOfStock;
            modelo.Price = model.Price;
            modelo.Stock = model.Stock;
            modelo.StockMin = model.StockMin;
            modelo.SubCategoryId = model.SubCategoryId;            


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


        // PUT: api/Products/Delete/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteProductViewModel model)
        {


            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.Products.FirstOrDefaultAsync(x => x.Id == model.Id);

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
