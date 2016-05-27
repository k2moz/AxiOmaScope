using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSharpGlNext.BL
{
    public interface IDiagrammerBaseLogic
    {
        void DrawAsix();
        void DrawPoints();
        void SetCamera();
        void SetRotate();
        void SetZoom();
        void Parse(string patch);
    }
}
