namespace API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Application.Models.Requests.Commands.Products;
using Application.Models.Requests.Queries.Categories;
using Application.Common.AppMediator;
using Application.Models.Requests.Queries.Products;

/// <summary>
/// Controller for managing products.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsController"/> class with the specified mediator.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public ProductsController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="command">The command</param>
    /// <returns>The result of the action.</returns>
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateProductAsync(CreateProductCommand command)
    {
        var res = await this._mediator.SendAsync(command);
        return this.StatusCode((int)res.StatusCode, res.Response);
    }

    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="query">The query</param>
    /// <returns>The result of the action.</returns>
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetProductByIdAsync([FromQuery] GetProductByIdQuery query)
    {
        var res = await this._mediator.SendAsync(query);
        return this.StatusCode((int)res.StatusCode, res.Response);
    }

    /// <summary>
    /// Retrieves a paginated list of products.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>The result of the action.</returns>
    [HttpGet]
    [Route("get/paginated")]
    public async Task<IActionResult> GetProductsPaginationAsync([FromQuery] GetProductsPaginationQuery query)
    {
        var res = await this._mediator.SendAsync(query);
        return this.StatusCode((int)res.StatusCode, res.Response);
    }

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>The result of the action.</returns>
    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateProductAsync(UpdateProductCommand command)
    {
        var res = await this._mediator.SendAsync(command);
        return this.StatusCode((int)res.StatusCode, res.Response);
    }

    /// <summary>
    /// Deletes a product by its ID.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>The result of the action.</returns>
    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> DeleteProductAsync(DeleteProductCommand command)
    {
        var res = await this._mediator.SendAsync(command);
        return this.StatusCode((int)res.StatusCode, res.Response);
    }

    private IMediator _mediator;
}
