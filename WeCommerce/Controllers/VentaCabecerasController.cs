using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeCommerce.Data;
using WeCommerce.Models;




namespace WeCommerce.Controllers
{
    public class VentaCabecerasController : Controller
    {
       
        private readonly ApplicationDbContext _context;

        public VentaCabecerasController(ApplicationDbContext context)
        {
            
            _context = context;
        }
       
        // GET: VentaCabeceras
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View(await _context.VentaCabecera.ToListAsync());
            }
            return View(await _context.VentaCabecera.Where(p=>p.IdUser==User.Identity.Name).ToListAsync());
        }

        // GET: VentaCabeceras/Usuario
        public async Task<IActionResult> IndexUsuario()
        {
            return View(await _context.VentaCabecera.Where(p => p.IdUser == User.Identity.Name).ToListAsync());
        }

        // GET: VentaCabeceras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaCabecera = await _context.VentaCabecera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventaCabecera == null)
            {
                return NotFound();
            }
            ventaCabecera.Details = _context.VentasDetalles.Where(vd => vd.VentaCabeceraId == id ).ToList();

            if (ventaCabecera.Details == null)
                ventaCabecera.Details = new List<VentaDetalle>();
            ViewBag.TotalVentas = ventaCabecera.Details.Sum(p => p.Price * p.Quntity);


            return View(ventaCabecera);
        }

        
        // GET: VentaCabeceras/Create
        public IActionResult Create()
        {
            if (ListProducts == null)
            {
                return RedirectToAction("Index", "ProductosVistaController1");
            }

            List<VentaDetalle> lstVentaDetalle = GetDetails();
            var ventacabecera = new VentaCabecera();
            ventacabecera.Details = lstVentaDetalle;
            //var products = _context.Product.Where(p => p.Id == 3 );

            return View(ventacabecera);
        }

        private static List<VentaDetalle> GetDetails()
        {
            var lstVentaDetalle = new List<VentaDetalle>();


            foreach (var item in ListProducts)
            {
                var ventaDetalle = new VentaDetalle();
                ventaDetalle.ProductId = item.IdProducts;
                ventaDetalle.Quntity = item.Cantidad;
                ventaDetalle.Price = item.Price;
                lstVentaDetalle.Add(ventaDetalle);
            }

            return lstVentaDetalle;
        }

        // POST: VentaCabeceras/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,IdUser,Details")] VentaCabecera ventaCabecera)
        {
            ventaCabecera.Details = GetDetails();
            if (ModelState.IsValid && ListProducts.Count>0)
            {
               
                if (User.Identity.IsAuthenticated)
                {
                   



                    var Usuario = User.Identity.Name;
                    ventaCabecera.IdUser = Usuario;
                    _context.Add(ventaCabecera);
                    
                    await _context.SaveChangesAsync();
                    ListProducts = new List<WeCartTemp>();
                    return RedirectToAction("IndexUsuario", ventaCabecera);
                }
              
            }
            
            return RedirectToAction("Create");
        }

        // GET: VentaCabeceras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaCabecera = await _context.VentaCabecera.FindAsync(id);
            if (ventaCabecera == null)
            {
                return NotFound();
            }
            return View(ventaCabecera);
        }

        // POST: VentaCabeceras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,IdUser")] VentaCabecera ventaCabecera)
        {
            if (id != ventaCabecera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaCabecera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaCabeceraExists(ventaCabecera.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ventaCabecera);
        }

        // GET: VentaCabeceras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaCabecera = await _context.VentaCabecera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventaCabecera == null)
            {
                return NotFound();
            }

            return View(ventaCabecera);
        }

        // POST: VentaCabeceras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaDetalles =  _context.VentasDetalles.Where(p=>p.VentaCabeceraId==id).ToList();
            foreach (var item in ventaDetalles)
            {
                _context.VentasDetalles.Remove(item);
                await _context.SaveChangesAsync();
            }
            var ventaCabecera = await _context.VentaCabecera.FindAsync(id);
            _context.VentaCabecera.Remove(ventaCabecera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaCabeceraExists(int id)
        {
            return _context.VentaCabecera.Any(e => e.Id == id);
        }


        private static List<WeCartTemp> ListProducts;
        public WeCartTemp AddProdCarrito(int IdProduct,int cantidad)
        {
            if (ListProducts==null)
            {
                ListProducts = new List<WeCartTemp>();
            }
            var productInList = ListProducts.Where(p => p.IdProducts == IdProduct).FirstOrDefault();
            if (productInList!=null)
            {
                productInList.Cantidad=productInList.Cantidad + cantidad;
            }
            else
            {
                var produts = _context.Product.Where(p=> p.Id==IdProduct).FirstOrDefault();
                productInList = new WeCartTemp() { IdProducts = IdProduct,Cantidad = cantidad,Price=produts.Price};

                ListProducts.Add(productInList);
            }
            productInList.TotalProducto = _context.Product.Where(p=>p.Id==IdProduct).FirstOrDefault().Price*productInList.Cantidad;
            
            var ret = ListProducts.Where(p=>p.IdProducts==IdProduct).FirstOrDefault();
            

            return ret;
        }

        public decimal GetTotalImport()
        {
            return ListProducts.Sum(t=>t.TotalProducto);


        }
        public int GetTotalCarrito()
        {
            if (ListProducts == null)
            {
                return 0;
            }
            return ListProducts.Where(t => t.IdProducts==t.IdProducts).Count();
        }
        public  bool DeleteProducto(int idproducto)
        {
            foreach (var item in ListProducts)
            {
                
                ListProducts.Where(p => p.IdProducts == idproducto).FirstOrDefault();
                ListProducts.Remove(item);
                 _context.SaveChangesAsync();
                return true;
            }
            
            return true;

        }

        public class WeCartTemp
        {
            public int IdProducts { get; set; }
            public int Cantidad { get; set; }
            public decimal Price { get; set; }


            public decimal TotalProducto { get; set; }

        }




    }
}
