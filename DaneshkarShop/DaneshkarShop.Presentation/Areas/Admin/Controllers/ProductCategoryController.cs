using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Domain.DTOs.AdminSide.Product;
using DaneshkarShop.Presentation.HttpManager;
using Microsoft.AspNetCore.Mvc;
namespace DaneshkarShop.Presentation.Areas.Admin.Controllers;

public class ProductCategoryController : AdminBaseController
{
    #region Ctor

    private readonly IProductCategoryService _productCategoryService;

    public ProductCategoryController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }

    #endregion

    #region List Of Parent Categories

    public async Task<IActionResult> FilterProductCategories(CancellationToken cancellationToken = default)
    {
        return View(await _productCategoryService.FilterProductCategories(cancellationToken));
    }

    #endregion

    #region Create Parent Category

    public async Task<IActionResult> CreateProductCategory(int? parentId ,
                                                           CancellationToken cancellationToken = default)
    {
        return View(new CreateProductCategoryDTO()
        {
            ParentId = parentId,
        });
    }

    [HttpPost , ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateProductCategory(CreateProductCategoryDTO model ,
                                                           CancellationToken cancellationToken = default)
    {
        #region Create Product Category

        if (ModelState.IsValid)
        {
            var res = await _productCategoryService.AddProductCategory(model , cancellationToken);
            if (res)
            {
                return RedirectToAction(nameof(FilterProductCategories));
            }
        }

        #endregion

        return View(model);
    }

    #endregion

    #region Edit Parent Category

    #endregion

    #region Edit Child Category 

    #endregion

    #region Delete Category

    [HttpGet]
    public async Task<IActionResult> DeleteCategory(int categoryId,
                                                    CancellationToken cancellation = default)
    {
        var res = await _productCategoryService.DeleteProductCategory(categoryId , cancellation);
        if (res)
        {
            return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "عملیات باموفقیت انجام شده است.");
        }

        return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "عملیات باشکست مواجه شده است.");
    }

    #endregion
}
