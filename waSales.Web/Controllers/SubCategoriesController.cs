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
    public class SubCategoriesController : ControllerBase
    {
        private readonly DbContextApp _context;

        public SubCategoriesController(DbContextApp context)
        {
            _context = context;
        }

        // GET: api/SubCategories
        [HttpGet("{companyId}")]
        public IEnumerable<IndexDependentViewModel> GetSubCategories([FromRoute] int companyId)
        {

            List<SubCategory> modelo = _context.SubCategories.Where(x => x.Enabled == true && x.Category.CompanyId == companyId).Include(x => x.Category).ToList();
            List<IndexDependentViewModel> list = new List<IndexDependentViewModel>();
            foreach (var item in modelo)
            {
                IndexDependentViewModel indexViewModel = new IndexDependentViewModel
                {
                    ParentId = item.CategoryId,
                    Parent = item.Category?.Description,
                    Description = item.Description,
                    Enabled = item.Enabled,
                    Id = item.Id

                };
                list.Add(indexViewModel);
            }

            return list;
        }


        // PUT: api/SubCategories/Create
        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] CreateDependentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubCategory modelo = new SubCategory
            {
                Description = model.Description,
                Enabled = true,
                CategoryId = model.ParentId
            };


            _context.SubCategories.Add(modelo);
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

        // POST: api/SubCategories/Update
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

            var modelo = await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == model.Id);

            modelo.Description = model.Description;
            modelo.CategoryId = model.ParentId;


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

            var modelo = await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == model.Id);

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
