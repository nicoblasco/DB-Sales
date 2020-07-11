using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using waSales.Data;
using waSales.Entities.Configuration;
using waSales.Web.Models.Configuration.Sector;

namespace waSales.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorsController : ControllerBase
    {
        private readonly DbContextApp _context;

        public SectorsController(DbContextApp context)
        {
            _context = context;
        }

        // GET: api/Sectors
        [HttpGet]
        public IEnumerable<SectorViewModel> GetSectors()
        {
            List<Sector> sectors = _context.Sectors.Where(x => x.Enabled).ToList();
            List<SectorViewModel> list = new List<SectorViewModel>(); 

            foreach (var item in sectors)
            {
                SectorViewModel  sector = new SectorViewModel
                {
                    Id=item.Id,
                    Description= item.Description,
                    Enabled = item.Enabled

                };
                list.Add(sector);
            }

            return list;

        }



    }
}