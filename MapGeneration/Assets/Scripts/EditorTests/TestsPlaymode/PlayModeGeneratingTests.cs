using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayModeGeneratingTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void PlayModeGeneratingTestsSimplePasses()
    {
        // Use the Assert class to test conditions
        var mapGenerator = new GameObject().AddComponent<MapGenerator>();
        
        TerrainData test = mapGenerator.TestTerrainSpawn();
        //Terrain terrain = mapGenerator.GetComponent<Terrain>();
        Assert.IsNotNull(test, "Terrain should be generated.");
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayModeGeneratingTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
