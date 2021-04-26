using System.Collections.Generic;

using UnityEngine;

public class WorldSectionHotSpotEnvironment : WorldSectionHotSpotBase
{
    [SerializeField] private List<GameObject> _features = null;
    [SerializeField] private List<Transform> _spawnPoints = null;

    private List<GameObject> _spawnedFeatures = new List<GameObject>();

    public override void Activate()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            SpawnRandomFeature(spawnPoint);
        }
    }

    public override void Deactivate()
    {
        DestroySpawnedFeatures();
    }

    private void SpawnRandomFeature(Transform parent)
    {
        var randomIndex = Random.Range(0, _features.Count);
        var randomFeature = _features[randomIndex];

        var spawnedFeature = GameObject.Instantiate(randomFeature, parent);
        _spawnedFeatures.Add(spawnedFeature);
    }

    private void DestroySpawnedFeatures()
    {
        foreach(var spawnedFeature in _spawnedFeatures)
        {
            GameObject.Destroy(spawnedFeature);
        }
        _spawnedFeatures.Clear();
    }
}
