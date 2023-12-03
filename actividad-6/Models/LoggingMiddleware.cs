namespace actividad_6.Models
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Registro antes del procesamiento
            LogRequest(context);

            await _next(context);

            // Registro después del procesamiento
            LogResponse(context);
        }

        private void LogRequest(HttpContext context)
        {
            var request = context.Request;

            // Puedes registrar más detalles según tus necesidades
            _logger.LogInformation($"Incoming request: {request.Method} {request.Path}");
        }

        private void LogResponse(HttpContext context)
        {
            var response = context.Response;

            // Puedes registrar más detalles según tus necesidades
            _logger.LogInformation($"Outgoing response: {response.StatusCode}");
        }

    }
}
