﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
namespace GODRenderPipeline
{
    public class ContextSubmit : MonoBehaviour, IRenderTreeItem
    {
        public void Render(ref ScriptableRenderContext context, GODRPParameters p)
        {
            context.Submit();
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
