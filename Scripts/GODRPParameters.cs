
using UnityEngine;
using UnityEngine.Rendering;

namespace GODRenderPipeline
{
    public class GODRPParameters
    {
        public CommandBuffer cb;
        public Camera[] cameras;
        public Camera camera;
        public int currentCameraIndex;
        public SortingSettings sortingSettings;
        public CullingResults cullingResults;
        public DrawingSettings drawingSettings;
        public FilteringSettings filteringSettings;
    }
}
