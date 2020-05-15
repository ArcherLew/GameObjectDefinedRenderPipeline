using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace GODRenderPipeline
{
    public class TreeCommandList : MonoBehaviour, IRenderTreeItem
    {
        public void Render(ref ScriptableRenderContext context, GODRPParameters p)
        {
            if (commandBuffer == null) commandBuffer = new CommandBuffer();
            p.cb = commandBuffer;
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
            context.ExecuteCommandBuffer(p.cb);
            p.cb.Clear();
        }
        List<MonoBehaviour> components = new List<MonoBehaviour>();
        CommandBuffer commandBuffer;
    }

}