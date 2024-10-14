namespace TXTextControl
{
    public class TXSecurityMiddleware
    {

        private IConfiguration configuration;

        public TXSecurityMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            m_next = next;
            this.configuration = configuration;
        }


        private RequestDelegate m_next;

        public async Task Invoke(HttpContext context)
        {

            var access_token = this.configuration.GetSection("Security")["AccessToken"];

            // Check if the request is a TX Text Control request
            if (context.WebSockets.IsWebSocketRequest &&
              context.WebSockets.WebSocketRequestedProtocols.Contains("TXTextControl.Web") ||
              (context.Request.Query.ContainsKey("access_token") &&
              context.GetEndpoint()?.DisplayName?.Contains("TXTextControl.Web.MVC.DocumentViewer") == true))
            {
                // Retrieve access token from the query string
                var accessToken = context.Request.Query["access_token"];

                // Showcase only: Easy comparison of tokens
                if (accessToken != access_token)
                {
                    throw new UnauthorizedAccessException();
                }
                else
                {
                    await m_next.Invoke(context);
                }
            }
            else if (m_next != null)
            {
                await m_next.Invoke(context);
            }
        }

    }

}