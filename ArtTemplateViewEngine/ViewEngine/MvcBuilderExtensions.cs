using ArtTemplateViewEngine.ViewEngine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddArtTemplate(this IMvcBuilder builder, Action<ArtTemplateViewEngineOptions> setupAction = null)
        {
            builder.Services.AddOptions().AddTransient<IConfigureOptions<ArtTemplateViewEngineOptions>, ArtTemplateViewEngineOptionsSetup>();

            if (setupAction != null)
                builder.Services.Configure(setupAction);

#pragma warning disable CS0618 // 类型或成员已过时
            builder.Services.AddTransient<IConfigureOptions<MvcViewOptions>, ArtTemplateMvcViewOptionsSetup>()
                            .AddSingleton<IArtTemplateViewEngine, ArtTemplateViewEngine.ViewEngine.ArtTemplateViewEngine>()
                            .AddNodeServices();
#pragma warning restore CS0618 // 类型或成员已过时
            return builder;
        }
    }
}
