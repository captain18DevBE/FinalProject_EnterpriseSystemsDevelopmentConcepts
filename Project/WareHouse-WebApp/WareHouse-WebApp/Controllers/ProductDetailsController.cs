﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WareHouse_WebApp.Data;
using WareHouse_WebApp.Models;
using WareHouse_WebApp.Service;

namespace WareHouse_WebApp.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GoodsReceipDetailDAO _goodsReceipDetailDAO;

        public ProductDetailsController(ApplicationDbContext context, GoodsReceipDetailDAO goodsReceipDetailDAO)
        {
            _context = context;
            _goodsReceipDetailDAO = goodsReceipDetailDAO;
        }

        // GET: ProductDetails
        public async Task<IActionResult> Index()
        {

            //Test Data
              //GoodsReceipDetail goodsReceipDetail = new GoodsReceipDetail();
              //goodsReceipDetail.GoodsReceipId = "RC01";
              //goodsReceipDetail.ProductId = "SP01";
            //await _goodsReceipDetailDAO.AddGoodsReceipDetail(goodsReceipDetail);

            //Test Data
              return _context.ProductDetail != null ? 
                          View(await _context.ProductDetail.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ProductDetail'  is null.");
        }

        // GET: ProductDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ProductDetail == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetail
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productDetail == null)
            {
                return NotFound();
            }

            return View(productDetail);
        }

        // GET: ProductDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Amount,CostPrice,ProductPhoto,Type,SellingPrice,Status,CatalogId")] ProductDetail productDetail)
        {
            if (ModelState.IsValid)
            {
                productDetail.DateOfBuy = DateTime.Now;
                _context.Add(productDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productDetail);
        }

        // GET: ProductDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ProductDetail == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetail.FindAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }
            return View(productDetail);
        }

        // POST: ProductDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProductId,ProductName,Amount,CostPrice,ProductPhoto,Type,SellingPrice,Status,CatalogId")] ProductDetail productDetail)
        {
            productDetail.DateOfBuy = DateTime.Now;
            ProductDetail productSave = await _context.ProductDetail.FindAsync(id);
            int amount = productSave.Amount;
            if (amount > productDetail.Amount)
            {
                productSave.Amount = amount - productDetail.Amount;
            }
            if (id != productSave.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductDetailExists(productSave.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["productId"] = productDetail.ProductId;
                TempData["amountProduct"] = productDetail.Amount;
                int result = productDetail.Amount * Decimal.ToInt32((decimal)productDetail.CostPrice);
                TempData["priceBill"] = result;
                return RedirectToAction("Create", "DeliveryNotes");
            }
            return View(productDetail);
        }

        // GET: ProductDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ProductDetail == null)
            {
                return NotFound();
            }

            var productDetail = await _context.ProductDetail
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productDetail == null)
            {
                return NotFound();
            }

            return View(productDetail);
        }

        // POST: ProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ProductDetail == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductDetail'  is null.");
            }
            var productDetail = await _context.ProductDetail.FindAsync(id);
            if (productDetail != null)
            {
                _context.ProductDetail.Remove(productDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDetailExists(string id)
        {
          return (_context.ProductDetail?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
