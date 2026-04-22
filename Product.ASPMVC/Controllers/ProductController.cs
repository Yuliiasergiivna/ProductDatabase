
using Microsoft.AspNetCore.Mvc;
using System;
using ProductLibrary.BLL.Entities;
using ProductLibrary.Common;
using System.Collections.Generic;
using ProductLibrary.ASPMVC.Models.Product;
using ProductLibrary.ASPMVC.Models.Stock;
using ProductLibrary.ASPMVC.Handlers;


namespace ProductLibrary.ASPMVC.Controllers
{ 
    public class ProductController : Controller
    {
        private readonly IProductRepository<Product> _bllService;
        private readonly UserSession _userSession;

        public ProductController(IProductRepository<Product> bllService, UserSession userSession)
        {
            _bllService = bllService;
            _userSession = userSession;
        }

        public IActionResult Index()
        {
            var products = _bllService.Get();
            IEnumerable<ListItemViewModel> viewModels = products.Select(p => new ListItemViewModel
            {
                ProductId =  p.ProductId,
                Name = p.Name,
                Description = p.Description,
                CurrentPrice = p.CurrentPrice,
                Stock = p.TotalStock,
                EntryCount = p.StockEntries.Count(),
                UserId = p.UserId
            });
            return View(viewModels);
        }
        public IActionResult Details(int id) 
        {
            var product = _bllService.Get(id);
            if (product == null) return NotFound();
            var viewModel = new DelailsViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                CurrentPrice = product.CurrentPrice,
                Stock = product.TotalStock,
                UserId = product.UserId,
                StockEntries = product.StockEntries.Select(s => new StockEntryViewModel
                {
                    EntryDate = s.EntryDate,
                    StockOperation = s.StockOperation
                }).ToList()
            };
            return View(viewModel);
        }
        public IActionResult Create() 
        {
            return View ();
        }
        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateForm form)
        {
            if (ModelState.IsValid)
            {
                if (_userSession.UserId == null)
                {
                    return RedirectToAction("Login", "User");
                }
                Guid currentUserId = _userSession.UserId.Value;
                var productCreate = new Product(form.Name, form.Description, form.CurrentPrice, currentUserId);

                _bllService.Create(productCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(form);
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        { 
            var product = _bllService.Get(id);
            if (product == null) return NotFound();
            EditProductViewModel vm = new EditProductViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                CurrentPrice = product.CurrentPrice,
                UserId = product.UserId,
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditProductViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (_userSession.UserId == null)
                {
                    return RedirectToAction("Login", "User");
                }
                Guid currentUserId = _userSession.UserId.Value;
                var productToUpdate = new Product(vm.ProductId, vm.Name, vm.Description, vm.CurrentPrice, currentUserId);
                try
                {
                    _bllService.Update(id, productToUpdate, currentUserId);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex) 
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(vm);
        }
        //[TypeFilter<NoStockEntry>]
        public IActionResult Delete(int id) 
        { 
            var product = _bllService.Get(id);
            if (product == null) return RedirectToAction(nameof(Index));
            if (product.StockEntries.Count() > 0) return RedirectToAction(nameof(Index));

            var vm = new DelailsViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                CurrentPrice = product.CurrentPrice,
                UserId = product.UserId,
                Stock = product.StockEntries.Sum(s => s.StockOperation)
            };
            return View(vm);
        }
        // POST: Product/Delete (Action réelle de suppression)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _bllService.Get(id);

            if (product.StockEntries != null && product.StockEntries.Any())
            {
                ModelState.AddModelError("", "Impossible de supprimer un produit avec un historique de stock.");
                var vm = new DelailsViewModel
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    CurrentPrice = product.CurrentPrice,
                    UserId = product.UserId,
                    Stock = product.StockEntries.Sum(s => s.StockOperation)
                };
                return View(vm);
            }
            _bllService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddStock (int id)
        {
            var product = _bllService.Get(id);
            if (product == null) return NotFound();

            var vm = new AddStockViewModel
            {
                ProductId = product.ProductId,
                Name = product.Name
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult AddStock(AddStockViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            if (_userSession.UserId == null)
            {
                return RedirectToAction("Login", "User");
            }
            Guid currentUserId = _userSession.UserId.Value;
            var product = _bllService.Get(vm.ProductId);
            int currentStock = product.StockEntries.Sum(s => s.StockOperation);
            
            if (vm.Quantity == 0)
            {
                ModelState.AddModelError("Quantity", "Veuillez saisir une quantité différente de zéro.");
                return View(vm);
            }

            //pour n'est pas aller dans le négatif
            if (vm.Quantity <0 && (currentStock + vm.Quantity)<0)
            {
                ModelState.AddModelError("Quantity", "Le stock ne peut pas être inférieur à zéro.");
                return View(vm);
            }
            //savegarder
            _bllService.AddStock(vm.ProductId, vm.Quantity, currentUserId);

            return RedirectToAction("Details", new { id = vm.ProductId });
            
        }
    }
}
