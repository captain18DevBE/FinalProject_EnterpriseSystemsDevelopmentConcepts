using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WareHouse_WebApp.Data;
using WareHouse_WebApp.Models;
using WareHouse_WebApp.Service;

namespace WareHouse_WebApp.Controllers
{
    public class GoodsReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GoodReceiptDAO _goodReceiptDAO;
        private readonly ManufacturersDAO _manufacturersDAO;
        private readonly ProductDetailDAO _productDetailDAO;
        private readonly UserManager<IdentityUser> _userManager;
        public GoodsReceiptsController(ApplicationDbContext context, GoodReceiptDAO goodReceiptDAO, ManufacturersDAO manufacturersDAO, ProductDetailDAO productDetailDAO, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _goodReceiptDAO = goodReceiptDAO;
            _manufacturersDAO = manufacturersDAO;
            _productDetailDAO = productDetailDAO;
            _userManager = userManager;
        }

        // GET: GoodsReceipts
        public async Task<IActionResult> Index()
        {
            //Manufacturer manufacturer = _manufacturersDAO.GetManufacturerById();
             return _context.GoodsReceipts != null ? 
                          View(await _context.GoodsReceipts.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GoodsReceipts'  is null.");
        }

        // GET: GoodsReceipts/Details/5
        public async Task<IActionResult> Details(string id)
        {
            string manufactId = "GR01";
            Manufacturer manufacturer = null;

            manufactId = Request.Query["manufac"];
            manufacturer = await _manufacturersDAO.GetManufacturerById(manufactId);
            TempData["Manufact"] = manufacturer;
            

            string productId = "SP01";
            ProductDetail product = null;
            productId = Request.Query["product"];
            product = await _productDetailDAO.GetProductById(productId);
            TempData["product"] = product;

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
        public async Task<IActionResult> Create()
        {
            var manu = _context.Manufacturer.ToList();
            var product = _context.ProductDetail.ToList();

            var cbReceipt = new CbReceipt
            {
                goodsReceipt = new GoodsReceipt(),
                manufacturers = manu,
                products = product,
            };
            //string productId = RouteData.Values["id"] as string;
            //GoodsReceipt getId = await _goodReceiptDAO.GetLastGoodsReceipt();
            //TempData["GoodsReceiptId"] = getId.GoodsReceiptId;
            //TempData["productId"] = productId;
            return View(cbReceipt);
        }

        // POST: GoodsReceipts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CbReceipt cbReceipt)
        {
            var goodsReceipt = cbReceipt.goodsReceipt;

            //goodsReceipt.ProductId = (string?) TempData["productId"];
            var user = await _userManager.GetUserAsync(User);
            goodsReceipt.GoodsReceiptId = GenerateDeliId();
            goodsReceipt.DateOfCreation = DateTime.Now;
            var product = await _context.ProductDetail.FindAsync(goodsReceipt.ProductId);

            product.Amount += cbReceipt.goodsReceipt.AmountProduct;
            if (user != null)
                {
                    string username = user.UserName;
                    goodsReceipt.EmployeeId = user.UserName;
                }
            _context.Add(goodsReceipt);
            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
            //return View(cbReceipt);
        }
        private string GenerateDeliId()
        {
            string lastEmployeeId = _context.GoodsReceipts.Max(e => e.GoodsReceiptId);

            if (string.IsNullOrEmpty(lastEmployeeId))
            {
                return "GR00001";
            }

            if (int.TryParse(lastEmployeeId[2..], out int number))
            {
                string nextNumber = (number + 1).ToString("00000");
                return $"GR{nextNumber}";
            }

            return "GR00001";
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
