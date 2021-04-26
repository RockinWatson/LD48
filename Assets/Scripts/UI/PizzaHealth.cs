using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaHealth : MonoBehaviour
{
    [SerializeField] private List<PizzaHealthSlice> _slices = null;

    private void Update()
    {
        var playerHealthPercent = Player.Get().GetHealthPercent();

        float threshold = 100f / _slices.Count;
        float currentThrehold = threshold;
        foreach (var slice in _slices)
        {
            var isActive = currentThrehold <= playerHealthPercent;
            slice.gameObject.SetActive(isActive);

            var nextThreshold = Mathf.Min(currentThrehold + threshold, 100f);
            var deltaPercent = 100f;
            if (playerHealthPercent < nextThreshold)
            {
                deltaPercent = (playerHealthPercent - currentThrehold) / threshold * 100f;
            }
            slice.SetPercentage(deltaPercent);

            currentThrehold = nextThreshold;
        }
    }
}
