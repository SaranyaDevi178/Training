using Microsoft.EntityFrameworkCore;
using CheckingWebApiEndpoint.Data;
using CheckingWebApiEndpoint.Models;
namespace CheckingWebApiEndpoint.Controllers;

public static class ProductEndpoints
{
    public static void MapProductEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Product", async (CheckingWebApiEndpointContext db) =>
        {
            return await db.Product.ToListAsync();
        })
        .WithName("GetAllProducts");

        routes.MapGet("/api/Product/{id}", async (int Id, CheckingWebApiEndpointContext db) =>
        {
            return await db.Product.FindAsync(Id)
                is Product model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetProductById");

        routes.MapPut("/api/Product/{id}", async (int Id, Product product, CheckingWebApiEndpointContext db) =>
        {
            var foundModel = await db.Product.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateProduct");

        routes.MapPost("/api/Product/", async (Product product, CheckingWebApiEndpointContext db) =>
        {
            db.Product.Add(product);
            await db.SaveChangesAsync();
            return Results.Created($"/Products/{product.Id}", product);
        })
        .WithName("CreateProduct");

        routes.MapDelete("/api/Product/{id}", async (int Id, CheckingWebApiEndpointContext db) =>
        {
            if (await db.Product.FindAsync(Id) is Product product)
            {
                db.Product.Remove(product);
                await db.SaveChangesAsync();
                return Results.Ok(product);
            }

            return Results.NotFound();
        })
        .WithName("DeleteProduct");
    }
}
