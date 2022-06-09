using Contract.Base.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Api.Framework.Base
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class BaseController : ControllerBase
    {
        protected IConfiguration Configuration = Common.ConfigurationManager.GetConfiguration();

        public new IActionResult Response<T>(T model, HttpStatusCode statusCode = default(HttpStatusCode)) where T : BaseApiResponse
        {
            var sCode = statusCode == default(HttpStatusCode) ? model.IsSucceed ? HttpStatusCode.OK : model.IsAccessDenied ? HttpStatusCode.Forbidden : HttpStatusCode.BadRequest : statusCode;

            return new ObjectResult(model) { StatusCode = (int)sCode };
        }
    }
}