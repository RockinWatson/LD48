using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 GetPosition() { return this.gameObject.transform.position; }

    private static Player _instance = null;
    public static Player Get() { return _instance; }

    private void Awake()
    {
        _instance = this;
    }
}
