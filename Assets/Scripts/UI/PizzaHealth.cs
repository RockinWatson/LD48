using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaHealth : MonoBehaviour
{
    [SerializeField] private List<PizzaHealthSlice> _slices = null;

    private static PizzaHealth _instance = null;
    public static PizzaHealth Get() { return _instance; }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        var playerHealthPercent = Player.Get().GetHealthPercent();

        float threshold = GetSinglePizzaPercent();
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

    public void AddPizza()
    {
        var percent = GetSinglePizzaPercent();
        Player.Get().AddHealthPercent(percent);
    }

    private float GetSinglePizzaPercent()
    {
        return 100f / _slices.Count;
    }
}
