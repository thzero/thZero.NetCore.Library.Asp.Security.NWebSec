using System;

using Microsoft.AspNetCore.Builder;

namespace thZero.Services
{
    public class ServiceHttpSecurityNWebSec : IServiceHttpSecurity
    {
        public void InitializeSsl(IApplicationBuilder app)
        {
            app.UseHsts(opts => opts.AllResponses());
        }

        public void InitializeStaticPost(IApplicationBuilder app)
        {
            app.UseXfo(xfo => xfo.Deny());
            app.UseRedirectValidation(); //Register this earlier if there's middleware that might redirect.
            app.UseNoCacheHttpHeaders();
        }

        public void InitializeStaticPre(IApplicationBuilder app)
        {
            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opts => opts.NoReferrer());
            app.UseXDownloadOptions();
            app.UseXXssProtection(opts => opts.Enabled());
        }
    }
}
