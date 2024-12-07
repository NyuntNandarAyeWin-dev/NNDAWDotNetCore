using Microsoft.IdentityModel.Tokens;
using NNDAWDotNetCore.Domain.Features.Blog;

namespace NNDAWDotNetCore.MinimalApi.Endpoint.Blog;

public static class BlogServiceEndpoint
{
    //public static string Test(int i)
    //{
    //    return i.ToString();
    //}
    private readonly static BlogService _service = new BlogService();
    
    public static void MapBlogServiceEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/blogs", () =>
        {
            var lst = _service.GetBlogs();
            return Results.Ok(lst);
        })
        .WithName("GetBlogs")
        .WithOpenApi();

        app.MapGet("/blogs/{id}", (int id) =>
        {
            var item = _service.GetBlog(id);
            if (item is null)
            {
                return Results.BadRequest("No Data Found");
            }

            return Results.Ok(item);
        })
        .WithName("GetBlog")
        .WithOpenApi();

        app.MapPost("/blogs", (TblBlog blog) =>
        {
            var model = _service.CreateBlog(blog);
            return Results.Ok(model);
        })
        .WithName("CreateBlog")
        .WithOpenApi();

        app.MapPut("/blogs/{id}", (int id, TblBlog blog) =>
        {
            var item = _service.UpdateBlog(id, blog);
            if (item is null)
            {
                return Results.BadRequest("No Data Found");
            }

            return Results.Ok(item);
        })
        .WithName("UpdateBlog")
        .WithOpenApi();

        app.MapDelete("/blogs/{id}", (int id) =>
        {
            var item = _service.DeleteBlog(id);
            if (item is null)
            {
                return Results.BadRequest("No Data Found");
            }

            return Results.Ok();
        })
        .WithName("DeleteBlog")
        .WithOpenApi();
    }
}
