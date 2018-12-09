using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace thZero.AspNetCore
{
    public class HttpSecurityNWebSecStartupExtension : IStartupExtension
    {
        #region Public Methods
        public virtual void ConfigurePost(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
        {
        }

        public virtual void ConfigurePre(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
        {
        }

        public virtual void ConfigureInitializePost(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider svp)
        {
        }

        public virtual void ConfigureInitializePre(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider svp)
        {
        }

        public virtual void ConfigureInitializeFinalPre(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
        {
        }

        public virtual void ConfigureInitializeFinalPost(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
        {
        }

        public virtual void ConfigureInitializeRoutesBuilderPost(IRouteBuilder routes)
        {
        }

        public virtual void ConfigureInitializeRoutesBuilderPre(IRouteBuilder routes)
        {
        }

        public virtual void ConfigureInitializeSsl(IApplicationBuilder app)
        {
#if !DEBUG
            app.UseHsts(opts => opts.AllResponses());
#endif
        }

        public virtual void ConfigureInitializeStaticPost(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
        {
            app.UseXfo(xfo => xfo.Deny());
            app.UseRedirectValidation(); //Register this earlier if there's middleware that might redirect.
            app.UseNoCacheHttpHeaders();
        }

        public virtual void ConfigureInitializeStaticPre(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
        {
            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opts => opts.NoReferrer());
            app.UseXDownloadOptions();
            app.UseXXssProtection(opts => opts.Enabled());
        }

        public virtual void ConfigureServicesPost(IServiceCollection services, IConfiguration configuration)
        {
        }

        public virtual void ConfigureServicesPre(IServiceCollection services, IConfiguration configuration)
        {
        }

        public virtual void ConfigureServicesInitializeMvcBuilderPost(IMvcBuilder builder)
        {
        }

        public virtual void ConfigureServicesInitializeMvcBuilderPre(IMvcBuilder builder)
        {
        }

        public virtual void ConfigureServicesInitializeMvcBuilderPost(IMvcCoreBuilder builder)
        {
        }

        public virtual void ConfigureServicesInitializeMvcBuilderPre(IMvcCoreBuilder builder)
        {
        }

        public virtual void ConfigureServicesInitializeMvcOptionsPost(MvcOptions options)
        {
        }

        public virtual void ConfigureServicesInitializeMvcOptionsPre(MvcOptions options)
        {
        }

        public virtual void ConfigureServicesInitializeMvcPost(IServiceCollection services, IConfiguration configuration)
        {
        }

        public virtual void ConfigureServicesInitializeMvcPre(IServiceCollection services, IConfiguration configuration)
        {
        }
        #endregion
    }
}
