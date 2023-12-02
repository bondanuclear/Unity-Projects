#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
/// <summary>
/// Class that implements spawning via GUI
/// </summary>
[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorGUI : Editor
{
    /// <summary>
    /// Spawnt maps through the GUI
    /// </summary>
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
