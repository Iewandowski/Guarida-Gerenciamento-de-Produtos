using System.Text.Json;

namespace gerenciamento_de_produto.config
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                await _next(context);

                if (context.Response.StatusCode == StatusCodes.Status400BadRequest &&
                    context.Response.ContentType?.ToLower().Contains("application/problem+json") == true)
                {
                    responseBody.Seek(0, SeekOrigin.Begin);
                    var responseBodyText = await new StreamReader(responseBody).ReadToEndAsync();

                    var problemDetails = JsonSerializer.Deserialize<JsonElement>(responseBodyText);

                    if (problemDetails.TryGetProperty("errors", out var errorsElement))
                    {
                        var errorMessages = new List<string>();

                        foreach (var property in errorsElement.EnumerateObject())
                        {
                            foreach (var error in property.Value.EnumerateArray())
                            {
                                var errorMessage = error.GetString();
                                if (errorMessage != null)
                                {
                                    errorMessages.Add(errorMessage);
                                }
                            }
                        }
                        context.Response.ContentType = "application/json";
                        context.Response.Body = originalBodyStream;
                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorMessages));
                    }
                    else
                    {
                        responseBody.Seek(0, SeekOrigin.Begin);
                        await responseBody.CopyToAsync(originalBodyStream);
                    }
                }
                else
                {
                    responseBody.Seek(0, SeekOrigin.Begin);
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
        }
    }

    public static class ValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidationMiddleware>();
        }
    }
}
