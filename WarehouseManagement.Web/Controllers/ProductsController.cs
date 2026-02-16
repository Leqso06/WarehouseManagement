using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Core.DTOs;
using WarehouseManagement.Core.Interfaces.Services;
using WarehouseManagement.Web.ViewModels;

namespace WarehouseManagement.Web.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        var result = await _productService.GetAllProductsAsync(page, pageSize);

        if (result.Success)
            return View(result.Data);

        return StatusCode(500, result.ErrorMessage);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var result = await _productService.GetProductByIdAsync(id);

        if (result.Success)
            return View(result.Data);

        return NotFound(result.ErrorMessage);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var categories = await _productService.GetCategoriesForFormAsync();
        var suppliers = await _productService.GetSuppliersForFormAsync();

        var result = new CreateProductViewModel
        {
            Categories = categories.Data,
            Suppliers = suppliers.Data
        };

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductViewModel model)
    {
        var result = await _productService.CreateProductAsync(model.Product);

        if (result.Success)
            return RedirectToAction("Index");

        return StatusCode(500, result.ErrorMessage);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        var categories = await _productService.GetCategoriesForFormAsync();
        var suppliers = await _productService.GetSuppliersForFormAsync();

        if (!product.Success)
            return NotFound(product.ErrorMessage);

        var productForm = new UpdateProductDto
        {
            ProductName = product.Data.ProductName,
            UnitPrice = product.Data.UnitPrice,
            UnitsInStock = product.Data.UnitsInStock,
            ReorderLevel = product.Data.ReorderLevel,
            PhotoUrl = product.Data.PhotoUrl,
        };

        var result = new EditProductViewModel
        {
            Product = productForm,
            Categories = categories.Data,
            Suppliers = suppliers.Data
        };

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EditProductViewModel model)
    {
        var result = await _productService.UpdateProductAsync(id, model.Product);

        if (result.Success)
            return RedirectToAction("Index");

        return StatusCode(500, result.ErrorMessage);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _productService.DeleteProductAsync(id);

        if (result.Success)
            return RedirectToAction("Index");

        return NotFound(result.ErrorMessage);
    }
}