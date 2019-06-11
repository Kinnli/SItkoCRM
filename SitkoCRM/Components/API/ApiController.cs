using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SitkoCRM.Components.Storage;

namespace SitkoCRM.Components.API
{
    [ApiController]
    public abstract class ApiController : Controller
    {
        protected ILogger Logger { get; }
        protected IStorage Storage { get; }

        protected DateTimeOffset DateStart => ParseDateQueryParams("dateStart");
        protected DateTimeOffset DateEnd => ParseDateQueryParams("dateEnd");

        public ApiController(ApiControllerContext context)
        {
            Logger = context.Logger;
            Storage = context.Storage;
        }

        private DateTimeOffset ParseDateQueryParams(string key, DateTimeOffset? defaultValue = null)
        {
            if (HttpContext != null && HttpContext.Request.Query.ContainsKey(key))
            {
                return DateTimeOffset.Parse(HttpContext.Request.Query[key]);
            }

            return defaultValue ?? DateTimeOffset.Now;
        }

        protected async Task<byte[]> GetBodyAsFileAsync()
        {
            using (var ms = new MemoryStream())
            {
                await Request.Body.CopyToAsync(ms);
                return ms.GetBuffer();
            }
        }
    }
}
