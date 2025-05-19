using Domain.Results;

namespace Domain.Models;

public class Category
{
    /// <summary>
    /// Gets or sets the id of the category.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets or sets the description of the category.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class with the specified properties.
    /// </summary>
    /// <param name="id">The of id of the category.</param>
    /// <param name="name">The of name of the category.</param>
    /// <param name="description">The of description of the category.</param>
    public Category(int id, string name, string description)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class with the specified properties.
    /// </summary>
    /// <param name="name">The of name of the category.</param>
    /// <param name="description">The of description of the category.</param>
    public Category(string name, string description)
    {
        this.Name = name;
        this.Description = description;
    }

    /// <summary>
    /// Tries to rename the category.
    /// </summary>
    /// <param name="newName">The new name.</param>
    /// <returns>The result of the operation.</returns>
    public Result TryRename(string newName)
    {
        if (newName is null)
        {
            return Result.GetFail(StatusCode.ArgumentNullError, "The argument <newName> was null");
        }

        this.Name = newName;
        return Result.GetSuccess(this, "The category was renamed successfully");
    }

    /// <summary>
    /// Tries to change the description of the category.
    /// </summary>
    /// <param name="newDescription">The new description.</param>
    /// <returns>The result of the operation.</returns>
    public Result TryChangeDescription(string newDescription)
    {
        if (newDescription is null)
        {
            return Result.GetFail(StatusCode.ArgumentNullError, "The argument <newDescription> was null");
        }

        this.Description = newDescription;
        return Result.GetSuccess(this, "The category was renamed successfully");
    }
}