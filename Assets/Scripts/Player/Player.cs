using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 GetPosition() { return this.gameObject.transform.position; }

    private Rigidbody2D _rigidbody2D = null;
    public Rigidbody2D GetRigidBody2d() { return _rigidbody2D; }

    private static Player _instance = null;
    public static Player Get() { return _instance; }

    private void Awake()
    {
        _instance = this;

        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }
}
