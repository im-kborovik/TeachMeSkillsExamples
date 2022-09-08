namespace Module17_ModelsAndViews.Middlewares;


public class MyMiddleware
{
    private readonly RequestDelegate _next;

    public MyMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Query.Keys.Contains("useMiddleware"))
        {
            await context.Response.WriteAsync("We are using custom middleware");
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}