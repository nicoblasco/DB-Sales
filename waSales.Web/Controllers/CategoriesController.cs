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
using waSales.Web.Models.Reusable.Tree;

namespace waSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DbContextApp _context;

        public CategoriesController(DbContextApp context)
        {
            _context = context;
        }

        // GET: api/Categories/5
        [HttpGet("{companyId}")]
        public IEnumerable<Category> GetCategories([FromRoute] int companyId)
        {
            return _context.Categories.Where(x => x.Enabled == true && x.CompanyId == companyId);
        }

        // GET: api/Categories/GetFull/5
        [HttpGet("[action]/{companyId}")]
        public IEnumerable<TreeViewModel> GetFull([FromRoute] int companyId)
        {

            List<Category> objects = _context.Categories.Where(x => x.CompanyId == companyId && x.Enabled).Include(x => x.SubCategories ).ToList();


            List<TreeViewModel> list = new List<TreeViewModel>();

            foreach (var category in objects.OrderBy(x => x.Description))
            {
                TreeViewModel comboCountry = new TreeViewModel
                {
                    Id = category.Id,
                    Label = category.Description,
                    Children = new List<TreeViewModel>()
                };

                foreach (var subcategory in category.SubCategories.OrderBy(x => x.Description))
                {
                    if (subcategory.Enabled)
                    {
                        TreeViewModel comboState = new TreeViewModel
                        {
                            Id = subcategory.Id,
                            Label = subcategory.Description
                        };

                        comboCountry.Children.Add(comboState);

                    }

                }

                list.Add(comboCountry);
            }



            return list;
        }

        // GET: api/Categories/GetComboFull/5
        [HttpGet("[action]/{companyId}")]
        public IEnumerable<ComboViewModel> GetComboFull([FromRoute] int companyId)
        {

            List<Category> objects = _context.Categories.Where(x => x.CompanyId == companyId && x.Enabled).Include(x => x.SubCategories).ToList();


            List<ComboViewModel> list = new List<ComboViewModel>();

            foreach (var category in objects.OrderBy(x => x.Description))
            {
                ComboViewModel comboCountry = new ComboViewModel
                {
                    Value = category.Id,
                    Label = category.Description,
                    Children = new List<ComboViewModel>()
                };

                foreach (var subcategory in category.SubCategories.OrderBy(x => x.Description))
                {
                    if (subcategory.Enabled)
                    {
                        ComboViewModel comboState = new ComboViewModel
                        {
                            Value = subcategory.Id,
                            Label = subcategory.Description
                        };

                        comboCountry.Children.Add(comboState);

                    }

                }

                list.Add(comboCountry);
            }



            return list;
        }

        // POST: api/Categories/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category modelo = new Category
            {
                Description = model.Description,
                CompanyId = model.CompanyId,
                Enabled = true
            };


            _context.Categories.Add(modelo);
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


        // PUT: api/Categories/Update/5
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

            var modelo = await _context.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);

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


        // PUT: api/Categories/Delete/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteViewModel model)
        {


            if (model.Id <= 0)
            {
                return BadRequest();
            }

            var modelo = await _context.Categories.FirstOrDefaultAsync(x => x.Id == model.Id);

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
