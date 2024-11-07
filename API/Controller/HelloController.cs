using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controller;

/// <summary>
/// Controller de Hello.
/// </summary>
public static class HelloController
{
    /// <summary>
    /// Adiciona os endpoints de Hello ao WebApplication.
    /// </summary>
    /// <param name="webApplication"></param>
    public static void AddEndpoints(this WebApplication webApplication)
    {
        var group = webApplication.MapGroup("hello").WithTags("Hello");

        group.MapPost("world", (int num, HelloService helloService) =>
                {
                    return helloService.HelloWorld(num).Match(
                        Results.Ok,
                        err => Results.Problem(detail: err.Message, statusCode: err.Code)
                    );
                }
            ).WithName("HelloWorld")
            .WithSummary("Retorna uma saudação ao mundo.")
            .WithDescription("Este endpoint retorna uma saudação ao mundo.")
            .WithMetadata(new ProducesResponseTypeAttribute(typeof(string), StatusCodes.Status200OK))
            .WithMetadata(new ProducesResponseTypeAttribute(typeof(ProblemDetails), StatusCodes.Status400BadRequest))
            .WithOpenApi();
    }
}