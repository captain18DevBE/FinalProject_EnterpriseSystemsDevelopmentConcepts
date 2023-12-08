using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WareHouse_WebApp.Components;
using WareHouse_WebApp.Data;
using WareHouse_WebApp.Models;
using WareHouse_WebApp.Service;

namespace WareHouse_WebApp.Controllers
{
    public class DeliveryNotesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly DeliveryNoteDAO _deliveryNoteDAO;
        private readonly CustomersDAO _customerDAO;
        private readonly ProductDetailDAO _productDetailDAO;
        private readonly UserManager<IdentityUser> _userManager;



        public DeliveryNotesController(ApplicationDbContext context, DeliveryNoteDAO deliveryNoteDAO, CustomersDAO customersDAO, ProductDetailDAO productDetailDAO, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _deliveryNoteDAO = deliveryNoteDAO;
            _customerDAO = customersDAO;
            _productDetailDAO = productDetailDAO;
            _userManager = userManager;
        }

        // GET: DeliveryNotes
        public async Task<IActionResult> Index()
        {
              
              return _context.DeliveryNotes != null ? 
                          View(await _context.DeliveryNotes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DeliveryNotes' is null.");
        }

        // GET: DeliveryNotes/Details/5
        public async Task<IActionResult> Details(string id)
        {

            string productId = "SP01";
            ProductDetail product = null;
            productId = Request.Query["product"];
            product = await _productDetailDAO.GetProductById(productId);

            //string serializedProduct = JsonSerializer.Serialize(product);
            //HttpContext.Session.SetString("product", serializedProduct);


            if (id == null || _context.DeliveryNotes == null)
            {
                return NotFound();
            }

            var deliveryNote = await _context.DeliveryNotes
                .FirstOrDefaultAsync(m => m.DeliveryNoteId == id);

            if (deliveryNote == null)
            {
                return NotFound();
            }

            return View(deliveryNote);
        }

        // GET: DeliveryNotes/Create
        public async Task<IActionResult> Create()
        {
            var product = _context.ProductDetail.ToList();
            var customer = _context.Customers.ToList();

            var cbDeliModel = new CbDeliModel
            {
                deliveryNotes = new DeliveryNote(),
                customers = customer,
                products = product
            };

            return View(cbDeliModel);
        }

        // POST: DeliveryNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CbDeliModel cbDeli)
        {
            var deliveryNote = cbDeli.deliveryNotes;
            var user = await _userManager.GetUserAsync(User);
            deliveryNote.DeliveryNoteId = GenerateDeliId();
            deliveryNote.DateOfCreation = DateTime.Now;

            var product = _context.ProductDetail.FirstOrDefault(p => p.ProductId == deliveryNote.ProductId);

            if (product != null)
            {
                product.Amount -= deliveryNote.AmountProduct;
                _context.SaveChanges();
            }
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    string username = user.UserName;
                    deliveryNote.EmployeeId = user.UserName;
                }

                _context.Add(deliveryNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryNote);
        }
        private string GenerateDeliId()
        {
            string lastEmployeeId = _context.DeliveryNotes.Max(e => e.DeliveryNoteId);

            if (string.IsNullOrEmpty(lastEmployeeId))
            {
                return "DL00001";
            }

            if (int.TryParse(lastEmployeeId[2..], out int number))
            {
                string nextNumber = (number + 1).ToString("00000");
                return $"DL{nextNumber}";
            }

            return "DL00001";
        }

        // GET: DeliveryNotes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DeliveryNotes == null)
            {
                return NotFound();
            }

            var deliveryNote = await _context.DeliveryNotes.FindAsync(id);
            if (deliveryNote == null)
            {
                return NotFound();
            }
            return View(deliveryNote);
        }

        // POST: DeliveryNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DeliveryNoteId,DateOfCreation,Status,TotalAmount,PayMethod,AmountPaid,AmountOwed")] DeliveryNote deliveryNote)
        {
            if (id != deliveryNote.DeliveryNoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryNoteExists(deliveryNote.DeliveryNoteId))
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
            return View(deliveryNote);
        }

        // GET: DeliveryNotes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DeliveryNotes == null)
            {
                return NotFound();
            }

            var deliveryNote = await _context.DeliveryNotes
                .FirstOrDefaultAsync(m => m.DeliveryNoteId == id);
            if (deliveryNote == null)
            {
                return NotFound();
            }

            return View(deliveryNote);
        }

        // POST: DeliveryNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DeliveryNotes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DeliveryNotes'  is null.");
            }
            var deliveryNote = await _context.DeliveryNotes.FindAsync(id);
            if (deliveryNote != null)
            {
                _context.DeliveryNotes.Remove(deliveryNote);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryNoteExists(string id)
        {
          return (_context.DeliveryNotes?.Any(e => e.DeliveryNoteId == id)).GetValueOrDefault();
        }
    }
}
