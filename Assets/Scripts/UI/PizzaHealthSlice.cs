using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaHealthSlice : MonoBehaviour
{
    [SerializeField] List<GameObject> _bites = null;

    public void SetPercentage(float percent)
    {
        float threshold = 100f / _bites.Count;
        float currentThrehold = threshold;
        foreach(var bite in _bites)
        {
            var isActive = currentThrehold <= percent;
            bite.gameObject.SetActive(isActive);

            currentThrehold += threshold;
        }
    }
}
