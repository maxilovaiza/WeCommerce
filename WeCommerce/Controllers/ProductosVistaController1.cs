using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeCommerce.Data;

namespace WeCommerce.Controllers
{
    public class ProductosVistaController1 : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductosVistaController1(ApplicationDbContext context)
        {
            _context = context;
           
        }



        // GET: ProductosVistaController1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: ProductosVistaController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductosVistaController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosVistaController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosVistaController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductosVistaController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductosVistaController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductosVistaController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
