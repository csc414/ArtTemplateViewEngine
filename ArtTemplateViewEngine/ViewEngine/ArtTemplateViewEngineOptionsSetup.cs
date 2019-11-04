using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtTemplateViewEngine.ViewEngine
{
    public class ArtTemplateViewEngineOptionsSetup : IConfigureOptions<ArtTemplateViewEngineOptions>
    {
        public void Configure(ArtTemplateViewEngineOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            options.ViewLocationFormats.Add("Views/{1}/{0}" + ArtTemplateViewEngine.ViewExtension);
            options.ViewLocationFormats.Add("Views/Shared/{0}" + ArtTemplateViewEngine.ViewExtension);

            options.AreaViewLocationFormats.Add("Areas/{2}/Views/{1}/{0}" + ArtTemplateViewEngine.ViewExtension);
            options.AreaViewLocationFormats.Add("Areas/{2}/Views/Shared/{0}" + ArtTemplateViewEngine.ViewExtension);
            options.AreaViewLocationFormats.Add("Views/Shared/{0}" + ArtTemplateViewEngine.ViewExtension);
        }
    }
}
