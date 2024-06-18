using UnityEngine;

namespace Bundos.WaterSystem
{
#if UNITY_EDITOR
    using UnityEditor;
#endif

#if UNITY_EDITOR
    [CustomEditor(typeof(Water))]
    public class WaterEditor : Editor
    {
        Water water;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            water = target as Water;

            water.Initialize();
            water.CreateShape();
            water.UpdateMesh();
        }
    }
#endif
}
