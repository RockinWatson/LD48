using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackgroundBounds : MonoBehaviour
{
    private PolygonCollider2D _collider2D = null;

    public Bounds GetBounds() { return _collider2D.bounds; }

    private static CameraBackgroundBounds _instance = null;
    public static CameraBackgroundBounds Get() { return _instance; }

    private void Awake()
    {
        _instance = this;

        _collider2D = this.GetComponent<PolygonCollider2D>();
    }

    private void FixedUpdate()
    {
        var position = this.transform.position;
        var playerPosition = Player.Get().transform.position;
        this.transform.position = new Vector3(position.x, playerPosition.y, position.z);
    }
}
