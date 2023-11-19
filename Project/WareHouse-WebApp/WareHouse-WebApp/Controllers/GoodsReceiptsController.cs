using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WareHouse_WebApp.Data;
using WareHouse_WebApp.Models;

namespace WareHouse_WebApp.Controllers
{
    public class GoodsReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsReceiptsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoodsReceipts
        public async Task<IActionResult> Index()
        {
              return _context.GoodsReceipts != null ? 
                          View(await _context.GoodsReceipts.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GoodsReceipts'  is null.");
        }

        // GET: GoodsReceipts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.GoodsReceipts == null)
            {
                return NotFound();
            }

            var goodsReceipt = await _context.GoodsReceipts
                .FirstOrDefaultAsync(m => m.GoodsReceiptId == id);
            if (goodsReceipt == null)
            {
                return NotFound();
            }

            return View(goodsReceipt);
        }

        // GET: GoodsReceipts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoodsReceipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GoodsReceiptId,Status,DateOfCreation,TotalAmount,Discount,AmountPaid,AmountOwed,PayMethod,EmployeeId")] GoodsReceipt goodsReceipt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goodsReceipt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goodsReceipt);
        }

        // GET: GoodsReceipts/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.GoodsReceipts == null)
            {
                return NotFound();
            }

            var goodsReceipt = await _context.GoodsReceipts.FindAsync(id);
            if (goodsReceipt == null)
            {
                return NotFound();
            }
            return View(goodsReceipt);
        }

        // POST: GoodsReceipts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("GoodsReceiptId,Status,DateOfCreation,TotalAmount,Discount,AmountPaid,AmountOwed,PayMethod,EmployeeId")] GoodsReceipt goodsReceipt)
        {
            if (id != goodsReceipt.GoodsReceiptId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goodsReceipt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsReceiptExists(goodsReceipt.GoodsReceiptId))
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
            return View(goodsReceipt);
        }

        // GET: GoodsReceipts/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.GoodsReceipts == null)
            {
                return NotFound();
            }

            var goodsReceipt = await _context.GoodsReceipts
                .FirstOrDefaultAsync(m => m.GoodsReceiptId == id);
            if (goodsReceipt == null)
            {
                return NotFound();
            }

            return View(goodsReceipt);
        }

        // POST: GoodsReceipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.GoodsReceipts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GoodsReceipts'  is null.");
            }
            var goodsReceipt = await _context.GoodsReceipts.FindAsync(id);
            if (goodsReceipt != null)
            {
                _context.GoodsReceipts.Remove(goodsReceipt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsReceiptExists(string id)
        {
          return (_context.GoodsReceipts?.Any(e => e.GoodsReceiptId == id)).GetValueOrDefault();
        }
    }
}
