using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtTemplateViewEngine.ViewEngine
{
    public class ArtTemplateMvcViewOptionsSetup : IConfigureOptions<MvcViewOptions>
    {
        private readonly IArtTemplateViewEngine _artTemplateViewEngine;

        public ArtTemplateMvcViewOptionsSetup(IArtTemplateViewEngine artTemplateViewEngine)
        {
            _artTemplateViewEngine = artTemplateViewEngine;
        }

        public void Configure(MvcViewOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            options.ViewEngines.Add(_artTemplateViewEngine);
        }
    }
}
