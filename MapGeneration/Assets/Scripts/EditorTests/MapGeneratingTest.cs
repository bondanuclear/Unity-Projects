using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
[TestFixture]
public class MapGeneratingTest
{
    
    // A Test behaves as an ordinary method
    [Test]
    public void MapGeneratingTestSimplePasses()
    {
        // Use the Assert class to test conditions
       
    }
    [UnityTest]
    public void MapGenerator_GeneratesTerrain()
    {
        // Arrange
        Transform gameObject = new GameObject().AddComponent<Transform>();
        
        // Act


    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator MapGeneratingTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
