using UnityEngine;
using UnityEngine.Rendering;

namespace GODRenderPipeline
{
    public interface IRenderTreeItem
    {
        void Render(ref ScriptableRenderContext context, GODRPParameters p);
    }
}