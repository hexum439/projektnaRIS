using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondHand.Data;
using SecondHand.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHand.Controllers
{
    public class KupiOblaciloController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public KupiOblaciloController(AppDbContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }
        public IActionResult Index(int id)
        {
            var oblacilo = _context.Oblacilas.Where(p => p.Id == id).ToList();
            return View(oblacilo);
        }
        public async Task<IActionResult> PotrditevAsync(int id)
        {
            var oblacila = await _context.Oblacilas.FindAsync(id);
            _context.Oblacilas.Remove(oblacila);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
