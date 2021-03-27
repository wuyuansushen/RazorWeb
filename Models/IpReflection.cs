using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace RazorWeb.Models
{
    public interface IIpReflection
    {
        public string GetIp();
    }

        public class XForward
        {
            public string ip { get; set; }
        }
        public class IpReflection :IIpReflection
        {
            private readonly IHttpContextAccessor _httpContextAccessor;
            public IpReflection(IHttpContextAccessor httpContextAccessor)
            {
                _httpContextAccessor = httpContextAccessor;
            }
            public string GetIp()
            {
                var headerPairs = _httpContextAccessor.HttpContext.Request.Headers;
                string XForIP = headerPairs["X-Forwarded-For"];
                if (XForIP == null)
                    XForIP = "Null";
                else
                    XForIP = (XForIP.Split(','))[0];
                XForward forJson = new XForward() { ip = XForIP };
                var jsonOut = JsonSerializer.Serialize<XForward>(forJson,options:(new JsonSerializerOptions{WriteIndented=true}));
                return jsonOut;
            }
        }
    
}
