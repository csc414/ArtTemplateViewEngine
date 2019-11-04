using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtTemplateViewEngine.ViewEngine
{
    public class ArtTemplateViewEngineOptions
    {
        public IList<string> AreaViewLocationFormats { get; } = new List<string>();

        public IList<string> ViewLocationFormats { get; } = new List<string>();
    }
}
