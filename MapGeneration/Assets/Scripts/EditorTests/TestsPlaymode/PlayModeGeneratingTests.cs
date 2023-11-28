using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
[TestFixture]
public class PlayModeGeneratingTests
{
    private GameObject _gameObject;
    private MapGenerator _mapGenerator;
    private Terrain _terrain;
    private PerlinNoiseMapGenerator _iMapGenerator;

    [SetUp]
    public void SetUp()
    {
        _gameObject = new GameObject();
        _mapGenerator = _gameObject.AddComponent<MapGenerator>();
        
        _terrain = _gameObject.AddComponent<Terrain>();
        _iMapGenerator = _gameObject.AddComponent<PerlinNoiseMapGenerator>();
    }
    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_gameObject);
    }
    // A Test behaves as an ordinary method
    [Test]
    public void CreatedTerrainIsNotNull()
    {
        _mapGenerator.Awake();
        TerrainData test = _mapGenerator.TestTerrainSpawn();
        Assert.IsNotNull(test, "Terrain should be generated.");
    }
    [Test]
    public void SizesCorrespond()
    {
        _mapGenerator.Awake();
        TerrainData test = _mapGenerator.TestTerrainSpawn();
        Assert.AreEqual(_mapGenerator.TerrainWidth+1, test.heightmapResolution, "TerrainData width should match terrainWidth.");
        Assert.AreEqual(_mapGenerator.TerrainLength+1, test.heightmapResolution, "TerrainData length should match terrainLength.");

    }

    [Test]
    public void TestSeedNotEqualZero()
    {
       _mapGenerator.RandomizeSeed = true;
        _mapGenerator.Awake();
        Assert.AreNotEqual(Vector2.zero, _mapGenerator.Seed, "Seed should not be Vector2.zero when randomizeSeed is true.");
    }
    [Test]
    public void TestSeedEqualZero()
    {
        _mapGenerator.RandomizeSeed = false;
        _mapGenerator.Awake();
        Assert.AreEqual(Vector2.zero, _mapGenerator.Seed, "Seed should not be Vector2.zero when randomizeSeed is true.");
    }
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    // [UnityTest]
    // public IEnumerator PlayModeGeneratingTestsWithEnumeratorPasses()
    // {
    //     // Use the Assert class to test conditions.
    //     // Use yield to skip a frame.
    //     yield return null;
    // }
}
