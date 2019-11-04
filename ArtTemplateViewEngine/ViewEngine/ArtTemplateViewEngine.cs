using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArtTemplateViewEngine.ViewEngine
{
    public class ArtTemplateViewEngine : IArtTemplateViewEngine
    {
        private readonly INodeServices _nodeServices;

        private readonly ArtTemplateViewEngineOptions _options;

        public ArtTemplateViewEngine(INodeServices nodeServices, IOptions<ArtTemplateViewEngineOptions> options)
        {
            _nodeServices = nodeServices;
            _options = options.Value;
        }

        public static readonly string ViewExtension = ".art";

        private const string AreaKey = "area";
        private const string ControllerKey = "controller";

        public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        {
            var controllerName = NormalizedRouteValue.GetNormalizedRouteValue(context, ControllerKey);
            var areaName = NormalizedRouteValue.GetNormalizedRouteValue(context, AreaKey);

            var searchedLocations = new List<string>();
            var viewLocations = areaName == null ? _options.ViewLocationFormats : _options.AreaViewLocationFormats;
            foreach (var location in viewLocations)
            {
                var path = string.Format(
                    CultureInfo.InvariantCulture,
                    location,
                    viewName,
                    controllerName,
                    areaName);

                if (File.Exists(path))
                    return ViewEngineResult.Found(viewName, new ArtTemplateView(_nodeServices, path));

                searchedLocations.Add(path);
            }

            return ViewEngineResult.NotFound(viewName, searchedLocations);
        }

        public ViewEngineResult GetView(string executingFilePath, string viewPath, bool isMainPage)
        {
            return ViewEngineResult.NotFound(viewPath, Enumerable.Empty<string>());
        }
    }
}
