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
using waSales.Entities.Provider;
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
        public IEnumerable<IndexProductViewModel> GetProducts([FromRoute] int companyId)
        {
            List<Product> products  = _context.Products.Where(x => x.Enabled && x.CompanyId == companyId).Include(x => x.Category).Include(x=>x.SubCategory).Include(x=>x.Brand).Include(x=>x.Location).Include(x=>x.ExchangeCurrency).ToList();
            List<IndexProductViewModel> list = new List<IndexProductViewModel>();
            string strRutaDefault = _config["ProductDefault"];

            foreach (var item in products)
            {
                IndexProductViewModel model = new IndexProductViewModel
                {
                    Id = item.Id,
                    Awaiting = item.Awaiting,
                    Brand = item.Brand?.Description,
                    BrandId= item.BrandId,
                    Category = item.Category?.Description,
                    CategoryId = item.CategoryId,
                    Codigo = item.Codigo,
                    Cost = item.Cost,
                    DateInitial = item.DateInitial.ToString("dd/MM/yyyy"),
                    Description = item.Description,
                    Discount = item.Discount,
                    ExchangeCurrency = item.ExchangeCurrency?.Description,
                    ExchangeCurrencyId = item.ExchangeCurrencyId,
                    Gain= item.Gain,
                    InStock = item.InStock,
                    Location = item.Location?.Description,
                    LocationId = item.LocationId,
                    Name = item.Name,
                    NameShort=item.NameShort,
                    OutOfStock = item.OutOfStock,
                    Price = item.Price,
                    Stock = item.Stock,
                    StockMin = item.StockMin,
                    SubCategory = item.SubCategory?.Description,
                    SubCategoryId = item.SubCategoryId,
                    CheckStock = item.CheckStock
                };

                if (!item.CheckStock.Value)
                {
                    if (item.InStock.Value)
                        model.Status = "En Stock";
                    if (item.OutOfStock.Value)
                        model.Status = "Sin Stock";
                    if (item.Awaiting.Value)
                        model.Status = "En Espera";
                }
                else
                { 
                    if (item.Stock>item.StockMin)
                    {
                        model.Status = "En Stock";
                    }
                    else
                    {
                        if (model.Stock <= item.StockMin && model.Stock > 0)
                            model.Status = "Ultimos";
                        else
                            model.Status = "Sin Stock";
                    }
                }


                if (!string.IsNullOrEmpty(item.Logo))
                {
                    byte[] imageArray = System.IO.File.ReadAllBytes(@item.Logo);
                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                    model.Logo = "data:image/png;base64," + base64ImageRepresentation;
                }
                else
                {
                    byte[] imageArray = System.IO.File.ReadAllBytes(strRutaDefault);
                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                    model.Logo = "data:image/png;base64," + base64ImageRepresentation;
                }

                list.Add(model);
            }

            return list.OrderBy(x => x.Name);
        }

        // GET: api/Products/id/5
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            Product product = await _context.Products.Where(x => x.Id == id).Include(x => x.ProductPriceLists).Include(x => x.ProductProviders).FirstOrDefaultAsync();
            string strRutaDefault = _config["ProductDefault"];


            UpdateProductViewModel model = new UpdateProductViewModel
            {
                    Id = product.Id,
                    Awaiting = product.Awaiting,
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    Codigo = product.Codigo,
                    Cost = product.Cost,
                    Description = product.Description,
                    Discount = product.Discount,
                    ExchangeCurrencyId = product.ExchangeCurrencyId,
                    Gain = product.Gain,
                    InStock = product.InStock,
                    LocationId = product.LocationId,
                    Name = product.Name,
                    NameShort = product.NameShort,
                    OutOfStock = product.OutOfStock,
                    Price = product.Price,
                    Stock = product.Stock,
                    StockMin = product.StockMin,
                    SubCategoryId = product.SubCategoryId,
                    CheckStock = product.CheckStock,
                    ProductPriceLists = new List<ProductPriceListsViewModel>(),
                    Providers = new List<int>()
                };


            foreach (var item in product.ProductPriceLists)
            {
                ProductPriceListsViewModel productPrice = new ProductPriceListsViewModel
                {
                    Id = item.Id,
                    Price = item.Price,
                    PriceList = item.PriceListId
                };
                model.ProductPriceLists.Add(productPrice);
            }

            foreach (var item in product.ProductProviders)
            {
                model.Providers.Add(item.ProviderId);
            }

              /*  if (!product.CheckStock.Value)
                {
                    if (product.InStock.Value)
                        model.Status = "En Stock";
                    if (product.OutOfStock.Value)
                        model.Status = "Sin Stock";
                    if (product.Awaiting.Value)
                        model.Status = "En Espera";
                }
                else
                {
                    if (product.Stock > product.StockMin)
                    {
                        model.Status = "En Stock";
                    }
                    else
                    {
                        if (model.Stock <= product.StockMin && model.Stock > 0)
                            model.Status = "Ultimos";
                        else
                            model.Status = "Sin Stock";
                    }
                }*/

                
                

                if (!string.IsNullOrEmpty(product.Logo))
                {
                    byte[] imageArray = System.IO.File.ReadAllBytes(@product.Logo);
                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                    model.Logo = "data:image/png;base64," + base64ImageRepresentation;
                }
             /*   else
                {
                    byte[] imageArray = System.IO.File.ReadAllBytes(strRutaDefault);
                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                    model.Logo = "data:image/png;base64," + base64ImageRepresentation;
                }*/



            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
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

            if (!string.IsNullOrEmpty(model.Codigo))
            {
                //Verifico si el codigo existe
                if (_context.Products.Where(x => x.Codigo == model.Codigo.ToUpper().Trim()).Any())
                {

                    return BadRequest(new { Message = "Código repetido" });
                }
            }



            Product modelo = new Product
            {
                Awaiting = model.Awaiting ?? false,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                Codigo = model.Codigo?.ToUpper().Trim(),
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
                Name = model.Name?.Trim(),
                NameShort = model.NameShort?.Trim(),
                OutOfStock = model.OutOfStock??false,
                Price = model.Price??0,
                Stock = model.Stock,
                StockMin = model.StockMin,
                SubCategoryId = model.SubCategoryId,
                CheckStock = model.CheckStock??false,
                ProductProviders = new List<ProductProviders>(),
                ProductPriceLists = new List<ProductPriceLists>()

            };

            foreach (var prov in model.Providers)
            {
                ProductProviders productProviders = new ProductProviders
                {
                    ProviderId = prov,
                    ProductId = modelo.Id
                };

                modelo.ProductProviders.Add(productProviders);
            }

            foreach (var price in model.ProductPriceLists)
            {
                ProductPriceLists productPriceLists = new ProductPriceLists
                {
                    PriceListId= price.PriceList,
                    ProductId= modelo.Id,
                    Price = price.Price
                };
                modelo.ProductPriceLists.Add(productPriceLists);
            }

            _context.Products.Add(modelo);
            try
            {
                await _context.SaveChangesAsync();



                
                if (modelo.Id > 0)
                {
                    //Codigo
                    if (string.IsNullOrEmpty(modelo.Codigo))
                    {
                        modelo.Codigo = modelo.Id.ToString();
                    }

                    //Guardo el avatar
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

            var modelo = await _context.Products.Where(x => x.Id == model.Id).Include(x => x.ProductPriceLists).Include(x => x.ProductProviders).FirstOrDefaultAsync();

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



            var providerToBeAdded = model.Providers.Where(a => modelo.ProductProviders.All(
            b => b.ProviderId != a));


            var providerToBeDeleted = modelo.ProductProviders.Where(a => model.Providers.All(
            b => b != a.ProviderId));


            foreach (var prov in providerToBeDeleted)
            {
                modelo.ProductProviders.Remove(prov);
            }

            foreach (var prov in providerToBeAdded)
            {
                ProductProviders productProviders = new ProductProviders
                {
                    ProviderId = prov,
                    ProductId = modelo.Id
                };

                modelo.ProductProviders.Add(productProviders);
            }


            foreach (var price in model.ProductPriceLists)
            {
                //Nuevos
                if (price.IsNew && price.IsRemoved==false)
                {
                    ProductPriceLists productPriceLists = new ProductPriceLists
                    {
                        PriceListId = price.PriceList,
                        ProductId = modelo.Id,
                        Price = price.Price
                    };
                    modelo.ProductPriceLists.Add(productPriceLists);
                }
                else
                {
                    if (!price.IsNew)
                    {
                        ProductPriceLists productPriceLists = modelo.ProductPriceLists.Where(x => x.Id == price.Id).FirstOrDefault();
                        //Borrados

                        if (price.IsNew == false && price.IsRemoved)
                        {
                            modelo.ProductPriceLists.Remove(productPriceLists);
                        }
                        else
                        {
                            //Actualizo
                            productPriceLists.Price = price.Price;
                            productPriceLists.PriceListId = price.PriceList;

                        }
                    }




                }
            }

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
