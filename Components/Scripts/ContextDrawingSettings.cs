using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace GODRenderPipeline
{
    public class ContextDrawingSettings : MonoBehaviour, IRenderTreeItem
    {
        public void Render(ref ScriptableRenderContext context, GODRPParameters p)
        {
            p.filteringSettings = new FilteringSettings(RenderQueueRange.opaque, -1);
            p.sortingSettings = new SortingSettings(p.camera) { criteria = SortingCriteria.CommonOpaque };
            p.drawingSettings = new DrawingSettings(new ShaderTagId(lightMode), p.sortingSettings);
            foreach (Transform child in transform)
            {
                if (!child.gameObject.activeInHierarchy) continue;
                child.GetComponents(components);
                for (int i = 0; i < components.Count; i++)
                {
                    if (components[i] is IRenderTreeItem renderTreeItem)
                    {
                        renderTreeItem.Render(ref context, p);
                    }
                }
            }
        }
        List<MonoBehaviour> components = new List<MonoBehaviour>();
        public string lightMode = "LightMode ";
        public RenderQueueRange renderQueueRange;
    }

}