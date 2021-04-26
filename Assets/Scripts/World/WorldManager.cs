using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [SerializeField] private float _totalDistanceRequired = 100f;

    [SerializeField] private WorldSection _firstSection = null;
    [SerializeField] private List<WorldSection> _worldSections = null;
    [SerializeField] private WorldSection _finalSection = null;

    private List<int> _activeIndices = new List<int>();
    private List<int> _inactiveIndices = new List<int>();

    private bool _isFirstSectionCurrent = false;
    private bool _isFinalSectionCurrent = false;

    private int _currentIndex = 0;

    private void Awake()
    {
        InitializeWorldSections();
    }

    private void Start()
    {
        // Spawn Player at Starting Position.
        SpawnPlayerAtStartPosition();
    }

    private void InitializeWorldSections()
    {
        // Set First Section to be active.
        _firstSection.gameObject.SetActive(true);
        _isFirstSectionCurrent = true;

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

        _finalSection.gameObject.SetActive(false);
        _isFinalSectionCurrent = false;
}

    private void SpawnPlayerAtStartPosition()
    {
        var player = Player.Get();
        player.gameObject.transform.position = _firstSection.GetPossiblePlayerStartPos().position;
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
        if(_isFinalSectionCurrent)
        {
            return;
        }

        var playerPosition = Player.Get().GetPosition();

        var currentWorldSection = GetCurrentWorldSection();
        var triggerPosition = currentWorldSection.GetTriggerPosition();

        if (playerPosition.y <= triggerPosition.y)
        {
            _isFirstSectionCurrent = false;

            // Trigger the next world section.

            WorldSection newWorldSection = null;
            if(HasPlayerTraveledRequiredDistance())
            {
                newWorldSection = _finalSection;
                _isFinalSectionCurrent = true;
            }
            else
            {
                // Pick a random inactive section to place.
                var randomIndex = Random.Range(0, _inactiveIndices.Count);
                var newWorldSectionIndex = _inactiveIndices[randomIndex];
                newWorldSection = _worldSections[newWorldSectionIndex];
                _inactiveIndices.Remove(newWorldSectionIndex);
                _activeIndices.Add(newWorldSectionIndex);
                _currentIndex = newWorldSectionIndex;
            }

            var currentSectionBounds = currentWorldSection.GetBoxCollider2D();
            var newSectionPlacementPosition = currentSectionBounds.bounds.min;
            newSectionPlacementPosition.x = currentSectionBounds.bounds.center.x;

            newWorldSection.Place(newSectionPlacementPosition);
        }
    }

    private WorldSection GetCurrentWorldSection()
    {
        if(_isFirstSectionCurrent)
        {
            return _firstSection;
        }
        if(_isFinalSectionCurrent)
        {
            return _finalSection;
        }
        return _worldSections[_currentIndex];
    }

    private void CullOldActiveWorldSections()
    {
        var playerPosition = Player.Get().GetPosition();
        var bounds = CameraBackgroundBounds.Get().GetBounds();
        var upperLimit = (bounds.size * 3f) + playerPosition;

        foreach(var activeIndex in _activeIndices)
        {
            var worldSection = _worldSections[activeIndex];
            if(worldSection.GetLowestPosition().y >= upperLimit.y)
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

        // Special case for First Section:
        if (_firstSection.gameObject.activeInHierarchy)
        {
            if (_firstSection.GetLowestPosition().y >= upperLimit.y)
            {
                _firstSection.Deactivate();
            }
        }
    }

    private bool HasPlayerTraveledRequiredDistance()
    {
        var startPosition = _firstSection.GetPossiblePlayerStartPos().position;
        var playerPosition = Player.Get().GetPosition();

        return ((playerPosition - startPosition).sqrMagnitude > _totalDistanceRequired * _totalDistanceRequired);
    }
}
