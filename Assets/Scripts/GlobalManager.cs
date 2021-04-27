using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    private static GlobalManager _instance = null;
    public static GlobalManager Get() { return _instance; }

    private float _pizzaHealthPercent = 25F;
    private float _pizzaDepth = 25F;
    private float _pizzaHeat = 25F;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(this.gameObject);
        }

        _instance = this;

        GameObject.DontDestroyOnLoad(_instance.gameObject);
    }

    public float GetPizzaHealthPercent()
    {
        return _pizzaHealthPercent;
    }

    public float GetPizzaDepth()
    {
        return _pizzaHealthPercent;
    }

    public float GetPizzaHeat()
    {
        return _pizzaHeat;
    }

    public void SetGameWinStats(float pizzaHealthPercent, float pizzaDepth, float pizzaHeat)
    {
        _pizzaHealthPercent = pizzaHealthPercent;
        _pizzaDepth = pizzaDepth;
        _pizzaHeat = pizzaHeat;
    }
}
