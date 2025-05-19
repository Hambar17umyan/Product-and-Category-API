
using Domain.Results;

namespace Domain.Models;

public class Product
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class with the specified properties.
    /// </summary>
    /// <param name="id">The id of the Product.</param>
    /// <param name="name">The name of the Product.</param>
    /// <param name="category1">The first categroy of the Product.</param>
    /// <param name="category2">The second category of the Product.</param>
    /// <param name="category3">The third category of the Product(if exists).</param>
    public Product(int id, string name, Category category1, Category category2, Category? category3 = default)
    {
        this.Id = id;
        this.Name = name;
        this.Category1 = category1;
        this.Category2 = category2;
        this.Category3 = category3;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class with the specified properties.
    /// </summary>
    /// <param name="name">The name of the Product.</param>
    /// <param name="category1">The first categroy of the Product.</param>
    /// <param name="category2">The second category of the Product.</param>
    /// <param name="category3">The third category of the Product(if exists).</param>
    public Product(string name, Category category1, Category category2, Category? category3 = default)
    {
        this.Name = name;
        this.Category1 = category1;
        this.Category2 = category2;
        this.Category3 = category3;
    }

    /// <summary>
    /// Gets or sets the id of the product.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets or sets the first category of the product.
    /// </summary>
    public Category Category1 { get; private set; }

    /// <summary>
    /// Gets or sets the second category of the product.
    /// </summary>
    public Category Category2 { get; private set; }

    /// <summary>
    /// Gets or sets the third category of the product (if exists).
    /// </summary>
    public Category? Category3 { get; private set; }

    /// <summary>
    /// Tries to rename the product.
    /// </summary>
    /// <param name="newName">The new name of the product.</param>
    /// <returns>The result of the operation.</returns>
    public Result TryRename(string newName)
    {
        if(newName is null)
        {
            return Result.GetFail(StatusCode.ArgumentNullError, "The argument <newName> was null");
        }

        this.Name = newName;
        return Result.GetSuccess(StatusCode.Success, "The product was renamed successfully");
    }

    /// <summary>
    /// Tries to modify the first category of the product.
    /// </summary>
    /// <param name="category">The modified category.</param>
    /// <returns>The result of the operation</returns>
    public Result TryModifyFirstCategory(Category category)
    {
        if (category is null)
        {
            return Result.GetFail(StatusCode.ArgumentNullError, "The argument <category> was null");
        }

        this.Category1 = category;
        return Result.GetSuccess(StatusCode.Success, "The first category was modified successfully");
    }

    /// <summary>
    /// Tries to modify the second category of the product.
    /// </summary>
    /// <param name="category">The modified category.</param>
    /// <returns>The result of the operation</returns>
    public Result TryModifySecondCategory(Category category)
    {
        if (category is null)
        {
            return Result.GetFail(StatusCode.ArgumentNullError, "The argument <category> was null");
        }

        this.Category2 = category;
        return Result.GetSuccess(StatusCode.Success, "The second category was modified successfully");
    }

    /// <summary>
    /// Tries to modify the third category of the product.
    /// </summary>
    /// <param name="category">The modified category.</param>
    /// <returns>The result of the operation</returns>
    public Result TryModifyThirdCategory(Category category)
    {
        this.Category2 = category;
        return Result.GetSuccess(StatusCode.Success, "The third category was modified successfully");
    }
}
