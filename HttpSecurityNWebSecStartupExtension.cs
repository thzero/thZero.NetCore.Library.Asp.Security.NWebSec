using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace thZero.AspNetCore
{
    public class HttpSecurityNWebSecStartupExtension : IStartupExtension
    {
        #region Public Methods
        public void InitializeMvcPost(IServiceCollection services, IConfigurationRoot configuration)
        {
        }

        public void InitializeMvcPre(IServiceCollection services, IConfigurationRoot configuration)
        {
        }

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
        #endregion
    }
}
