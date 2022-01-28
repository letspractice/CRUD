using EFDbContext.Data;
using EFDbContext.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EFDbContext.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tickets = await _context.TravelTicket.ToListAsync();
            return View(tickets);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TravelTicket obj)
        {
            if (ModelState.IsValid)
            {
                _context.TravelTicket.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var ticket = await _context.TravelTicket.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TravelTicket obj)
        {
            if (ModelState.IsValid)
            {
                _context.TravelTicket.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(obj);
        }
        public async Task<IActionResult> Details(int? ticketId)
        {
            var ticket = await _context.TravelTicket.FindAsync(ticketId);

            if (ticketId == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var ticket = await _context.TravelTicket.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _context.TravelTicket.FindAsync(id);
            _context.TravelTicket.Remove(ticket);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
