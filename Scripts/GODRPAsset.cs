using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace GODRenderPipeline
{
    [CreateAssetMenu(menuName = "Rendering/Create GODRenderPipeline Assets",fileName ="GODRenderPipeline")]
    public class GODRPAsset : RenderPipelineAsset
    {
        protected override RenderPipeline CreatePipeline()
        {
            GODRP GODRP = new GODRP();
            return GODRP;
        }
    }
}