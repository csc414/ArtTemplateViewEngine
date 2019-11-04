using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.NodeServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArtTemplateViewEngine.ViewEngine
{
    public class ArtTemplateView : IView
    {
        private readonly INodeServices _nodeServices;

        public ArtTemplateView(INodeServices nodeServices, string path)
        {
            _nodeServices = nodeServices;
            Path = path;
        }

        public string Path { get; }

        public async Task RenderAsync(ViewContext context)
        {
            var fileInfo = new FileInfo(Path);
            var html = await _nodeServices.InvokeExportAsync<string>("./art-template", "render", fileInfo.FullName, context.ViewData.Model);
            context.Writer.Write(html);
        }
    }
}
