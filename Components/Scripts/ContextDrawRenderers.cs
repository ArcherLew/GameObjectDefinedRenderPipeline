using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace GODRenderPipeline
{
    public class ContextDrawRenderers : MonoBehaviour, IRenderTreeItem
    {
        public void Render(ref ScriptableRenderContext context, GODRPParameters p)
        {
            context.DrawRenderers(p.cullingResults, ref p.drawingSettings, ref p.filteringSettings);
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
    }

}