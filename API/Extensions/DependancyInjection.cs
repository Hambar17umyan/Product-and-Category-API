namespace API.Extensions;

using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Common.Constants;
using Application.Models.Requests.Commands.Categories;
using Application.Models.Requests.Commands.Products;
using Application.Models.Requests.Queries.Categories;
using Application.Models.Requests.Queries.Products;
using Application.Models.Response.Commands.Categories;
using Application.Models.Response.Commands.Products;
using Application.Models.Response.Queries.Categories;
using Application.Models.Response.Queries.Products;
using Application.RequestHandlers.CommandHandlers.Categories;
using Application.RequestHandlers.CommandHandlers.Products;
using Application.RequestHandlers.QueryHandlers.Categories;
using Application.RequestHandlers.QueryHandlers.Products;
using Application.Services.ModelServices;
using Infrastructure.Data.DB;
using Infrastructure.Data.Repositories.Abstract;
using Infrastructure.Data.Repositories.Concrete;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

/// <summary>
/// This class is used to configure the dependancy injection for the application.
/// </summary>
public static class DependancyInjection
{
    /// <summary>
    /// This method is used to configure the dependancy injection for the application.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The builder.</returns>
    public static WebApplicationBuilder ConfigureDependancyInjection(this WebApplicationBuilder builder)
    {
        builder.InjectBuiltInServices();
        builder.InjectRepositories();
        builder.InjectServices();
        builder.InjectDbContext();
        builder.InjectMedaitor();
        builder.InjectRequestHandlers();
        return builder;
    }

    /// <summary>
    /// This method is used to configure the dependancy injection for the repositories.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The builder.</returns>
    private static void InjectRepositories(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<ICategoryRepository, CategoryRepository>();
    }

    /// <summary>
    /// This method is used to configure the dependancy injection for the services.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The builder.</returns>
    private static void InjectServices(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IProductService, ProductService>()
            .AddScoped<ICategoryService, CategoryService>();
    }

    /// <summary>
    /// This method is used to configure the dependancy injection for the built in services.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The builder.</returns>
    private static void InjectBuiltInServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    /// <summary>
    /// This method is used to configure the dependancy injection for the db context.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The builder.</returns>
    private static void InjectDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(AppConstants.DefaultConnectionString);
    }

    /// <summary>
    /// This method is used to configure the dependancy injection for the mediator.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The builder.</returns>
    private static void InjectMedaitor(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IMediator, Mediator>();
    }

    /// <summary>
    /// This method is used to configure the dependancy injection for the request handlers.
    /// </summary>
    /// <param name="builder">The builder.</param>
    /// <returns>The builder.</returns>
    private static void InjectRequestHandlers(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRequestHandler<CreateCategoryCommand, RequestHandlerResult<CreateCategoryResponse>>, CreateCategoryCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<DeleteCategoryCommand, RequestHandlerResult<DeleteCategoryResponse>>, DeleteCategoryCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<UpdateCategoryCommand, RequestHandlerResult<UpdateCategoryResponse>>, UpdateCategoryCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<GetCategoryByIdQuery, RequestHandlerResult<GetCategoryByIdResponse>>, GetCategoryByIdQueryHandler>();
        builder.Services.AddScoped<IRequestHandler<GetCategoriesPaginationQuery, RequestHandlerResult<GetCategoriesPaginationResponse>>, GetCategoriesPaginationQueryHandler>();

        builder.Services.AddScoped<IRequestHandler<CreateProductCommand, RequestHandlerResult<CreateProductResponse>>, CreateProductCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<DeleteProductCommand, RequestHandlerResult<DeleteProductResponse>>, DeleteProductCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<UpdateProductCommand, RequestHandlerResult<UpdateProductResponse>>, UpdateProductCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<GetProductByIdQuery, RequestHandlerResult<GetProductByIdResponse>>, GetProductByIdQueryHandler>();
        builder.Services.AddScoped<IRequestHandler<GetProductsPaginationQuery, RequestHandlerResult<GetProductsPaginationResponse>>, GetProductsPaginationQueryHandler>();
    }
}
