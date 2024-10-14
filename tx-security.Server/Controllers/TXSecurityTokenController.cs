using Microsoft.AspNetCore.Mvc;

namespace tx_security.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TXSecurityTokenController : ControllerBase
    {
        private IConfiguration configuration;

        public TXSecurityTokenController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public SecurityToken Get()
        {
            return new SecurityToken() { AccessToken = this.configuration.GetSection("Security")["AccessToken"] };
        }
    }
}
