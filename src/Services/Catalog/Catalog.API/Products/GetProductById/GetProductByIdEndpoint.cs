using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProductById
{
    //public record GetProfuctByIdRequest();
    public record GetProductByCategoryResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}",async (Guid id,ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));

                var response = result.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(response);
            }).WithName("GetProductById")
                .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get ProductById")
                .WithDescription("Get ProductById");
        }
    }
}
