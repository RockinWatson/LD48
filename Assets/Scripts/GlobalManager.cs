using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    private static GlobalManager _instance = null;
    public static GlobalManager Get() { return _instance; }

    private float _playerHealthPercent = 25F;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(this.gameObject);
        }

        _instance = this;

        GameObject.DontDestroyOnLoad(_instance.gameObject);
    }

    public float GetPlayerHealthPercent()
    {
        return _playerHealthPercent;
    }
}
