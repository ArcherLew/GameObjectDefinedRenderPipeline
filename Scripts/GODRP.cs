using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace GODRenderPipeline
{
    public class GODRP : RenderPipeline
    {
        protected override void Render(ScriptableRenderContext context, Camera[] cameras)
        {
            if (RenderTreeRoot == null)
            {
                RenderTreeRoot = GameObject.Find("RenderTreeRoot");
                if (RenderTreeRoot == null)
                    return;
            }
            if (cameras.Length == 0) return;
            GODRPParameters parameters = new GODRPParameters()
            {
                cameras = cameras,
                camera = cameras[0],
                currentCameraIndex = 0
            };
            context.SetupCameraProperties(parameters.camera);
            RenderTreeRoot.GetComponents(components);
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] is IRenderTreeItem renderTreeItem)
                {
                    renderTreeItem.Render(ref context, parameters);
                }
            }
        }
        List<MonoBehaviour> components = new List<MonoBehaviour>();
        public GameObject RenderTreeRoot;
    }
}
