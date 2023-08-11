using Sitecore.Configuration;
using Sitecore.Pipelines.HttpRequest;
using SXA.Theme.Optimizations.Constants;
using System.Web;

namespace SXA.Theme.Optimizations.Pipelines
{
    public class AddSecurityHeaders : HttpRequestProcessor
    {
        private const string _startPath = "/sitecore%20modules/Web/SXAThemeOptimizations";

        public override void Process(HttpRequestArgs args)
        {
            if (args?.Aborted == false && HttpContext.Current?.Request?.HttpMethod == "GET" && HttpContext.Current?.Request?.Url.AbsolutePath.StartsWith(_startPath) == true)
            {
                if (Settings.GetBoolSetting(SitecoreSettings.AddSecurityHeaders, true))
                {
                    HttpContext.Current.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
                    HttpContext.Current.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                    HttpContext.Current.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");
                }
            }
        }
    }
}