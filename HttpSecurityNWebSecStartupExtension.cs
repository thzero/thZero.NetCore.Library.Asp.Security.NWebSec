/* ------------------------------------------------------------------------- *
thZero.NetCore.Library.Asp.Security.NWebSec
Copyright (C) 2016-2018 thZero.com

<development [at] thzero [dot] com>

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 * ------------------------------------------------------------------------- */

using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace thZero.AspNetCore
{
    public class HttpSecurityNWebSecStartupExtension : BaseStartupExtension
    {
        #region Public Methods
        public override void ConfigureInitializeSsl(IApplicationBuilder app)
        {
            base.ConfigureInitializeSsl(app);

#if !DEBUG
            app.UseHsts(opts => opts.AllResponses());
#endif
        }

        public override void ConfigureInitializeStaticPost(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
        {
            base.ConfigureInitializeStaticPost(app, env, svp);

            app.UseXfo(xfo => xfo.Deny());
            app.UseRedirectValidation(); //Register this earlier if there's middleware that might redirect.
            app.UseNoCacheHttpHeaders();
        }

        public override void ConfigureInitializeStaticPre(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
        {
            base.ConfigureInitializeStaticPre(app, env, svp);

            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opts => opts.NoReferrer());
            app.UseXDownloadOptions();
            app.UseXXssProtection(opts => opts.Enabled());
        }
        #endregion
    }
}
