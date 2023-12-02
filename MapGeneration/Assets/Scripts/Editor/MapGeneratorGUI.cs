#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorGUI : Editor
{
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MapGenerator mapGenerator = (MapGenerator)target;
        Terrain terrain = FindObjectOfType<Terrain>();
        IMapGenerator generator = FindObjectOfType<PerlinNoiseMapGenerator>();
        mapGenerator.Initialize(generator, terrain);
        if (GUILayout.Button("Generate Map"))
        {
            mapGenerator.GenerateIMapGenerator();
        }
    }
}
#endif
