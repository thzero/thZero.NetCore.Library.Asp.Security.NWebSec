using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace thZero.AspNetCore
{
    public class HttpSecurityNWebSecStartupExtension : IStartupExtension
    {
        #region Public Methods
        public virtual void InitializeFinalPre(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider svp)
        {
        }

        public virtual void InitializeFinalPost(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider svp)
        {
        }

        public virtual void InitializeMvcPost(IServiceCollection services, IConfigurationRoot configuration)
        {
        }

        public virtual void InitializeMvcPre(IServiceCollection services, IConfigurationRoot configuration)
        {
        }

        public virtual void InitializeRoutesBuilderPost(IRouteBuilder routes)
        {
        }

        public virtual void InitializeRoutesBuilderPre(IRouteBuilder routes)
        {
        }

        public virtual void InitializeSsl(IApplicationBuilder app)
        {
            app.UseHsts(opts => opts.AllResponses());
        }

        public virtual void InitializeStaticPost(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
        {
            app.UseXfo(xfo => xfo.Deny());
            app.UseRedirectValidation(); //Register this earlier if there's middleware that might redirect.
            app.UseNoCacheHttpHeaders();
        }

        public virtual void InitializeStaticPre(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
        {
            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opts => opts.NoReferrer());
            app.UseXDownloadOptions();
            app.UseXXssProtection(opts => opts.Enabled());
        }
        #endregion
    }
}
