using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private List<WorldSection> _worldSections = null;

    private List<int> _activeIndices = new List<int>();
    private List<int> _inactiveIndices = new List<int>();

    private int _currentIndex = 0;

    private void Awake()
    {
        UpdateIndicesTracking();

        _currentIndex = _activeIndices[0];
    }

    private void UpdateIndicesTracking()
    {
        for (var i = 0; i < _worldSections.Count; ++i)
        {
            var worldSection = _worldSections[i];
            if (worldSection.gameObject.activeInHierarchy)
            {
                _activeIndices.Add(i);
            }
            else
            {
                _inactiveIndices.Add(i);
            }
        }
    }

    private void Update()
    {
        UpdateWorldState();
    }

    private void UpdateWorldState()
    {
        PlacePossibleNewWorldSection();

        CullOldActiveWorldSections();
    }

    private void PlacePossibleNewWorldSection()
    {
        var playerPosition = Player.Get().GetPosition();

        var currentWorldSection = _worldSections[_currentIndex];
        var triggerPosition = currentWorldSection.GetTriggerPosition();

        if (playerPosition.y <= triggerPosition.y)
        {
            // Trigger the next world section.
            var currentSectionBounds = currentWorldSection.GetBoxCollider2D();

            var newSectionPlacementPosition = currentSectionBounds.bounds.min;
            newSectionPlacementPosition.x = currentSectionBounds.bounds.center.x;

            // Pick a random inactive section to place.
            var randomIndex = Random.Range(0, _inactiveIndices.Count);
            var newWorldSectionIndex = _inactiveIndices[randomIndex];
            var newWorldSection = _worldSections[newWorldSectionIndex];
            _inactiveIndices.Remove(newWorldSectionIndex);
            _activeIndices.Add(newWorldSectionIndex);

            newWorldSection.Place(newSectionPlacementPosition);

            _currentIndex = newWorldSectionIndex;
        }
    }

    private void CullOldActiveWorldSections()
    {
        var playerPosition = Player.Get().GetPosition();
        var bounds = CameraBackgroundBounds.Get().GetBounds();
        var upperLimit = (bounds.size * 1.5f) + playerPosition;

        foreach(var activeIndex in _activeIndices)
        {
            var worldSection = _worldSections[activeIndex];
            if(worldSection.GetPosition().y >= upperLimit.y)
            {
                worldSection.Deactivate();
                //_activeIndices.Remove(activeIndex);
                _inactiveIndices.Add(activeIndex);
            }
        }
        foreach(var inactiveIndex in _inactiveIndices)
        {
            _activeIndices.Remove(inactiveIndex);
        }
    }
}
