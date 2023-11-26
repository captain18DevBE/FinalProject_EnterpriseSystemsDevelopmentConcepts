using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public DeliveryNotesController(ApplicationDbContext context, DeliveryNoteDAO deliveryNoteDAO, CustomersDAO customersDAO, ProductDetailDAO productDetailDAO)
        {
            _context = context;
            _deliveryNoteDAO = deliveryNoteDAO;
            _customerDAO = customersDAO;
            _productDetailDAO = productDetailDAO;
        }

        // GET: DeliveryNotes
        public async Task<IActionResult> Index()
        {
              
              return _context.DeliveryNotes != null ? 
                          View(await _context.DeliveryNotes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DeliveryNotes'  is null.");
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
            DeliveryNote deliveryNote = await _deliveryNoteDAO.getLastAsync();
            TempData["LastdeliveryNoteId"] = deliveryNote.DeliveryNoteId;
            TempData.Keep("productId");
            TempData.Keep("amountProduct");
            return View();
        }

        // POST: DeliveryNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryNoteId,ProductId,CustomerId,EmployeeId,Status,TotalAmount,AmountPaid,AmountOwed,PayMethod")] DeliveryNote deliveryNote)
        {
            deliveryNote.DateOfCreation = DateTime.Now;
           //var tmp = deliveryNote.
            if (ModelState.IsValid)
            {
                _context.Add(deliveryNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryNote);
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
