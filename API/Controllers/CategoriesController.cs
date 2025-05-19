namespace API.Controllers;

using Microsoft.AspNetCore.Mvc;
using Application.Models.Requests.Queries.Categories;
using Application.Models.Requests.Commands.Categories;
using Application.Common.AppMediator;
using System.Threading.Tasks;

/// <summary>
/// Controller for managing categories.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CategoriesController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator.</param>
    public CategoriesController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>The result of action</returns>
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        var res = await this._mediator.SendAsync(command);
        return this.StatusCode((int)res.StatusCode, res.Response);
    }

    /// <summary>
    /// Retrieves a category by its ID.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>The result of action.</returns>
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetCategoryByIdAsync([FromQuery]GetCategoryByIdQuery query)
    {
        var res = await this._mediator.SendAsync(query);
        return this.StatusCode((int)res.StatusCode, res.Response);
    }

    /// <summary>
    /// Retrieves a paginated list of categories.
    /// </summary>
    /// <param name="query">The query</param>
    /// <returns>The result of action.</returns>
    [HttpGet]
    [Route("get/paginated")]
    public async Task<IActionResult> GetCategoriesPagination([FromQuery]GetCategoriesPaginationQuery query)
    {
        var res = await this._mediator.SendAsync(query);
        return this.StatusCode((int)res.StatusCode, res.Response);
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>The result of action.</returns>
    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryCommand command)
    {
        var res = await this._mediator.SendAsync(command);
        return this.StatusCode((int)res.StatusCode, res.Response);
    }

    /// <summary>
    /// Deletes a category by its ID.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>The result of action.</returns>
    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand command)
    {
        var res = await this._mediator.SendAsync(command);
        return this.StatusCode((int)res.StatusCode, res.Response);
    }

    /// <summary>
    /// The mediator instance used for sending commands and queries.
    /// </summary>
    private IMediator _mediator;
}
