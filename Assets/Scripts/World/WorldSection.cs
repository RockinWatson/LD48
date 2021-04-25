using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSection : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider2D = null;
    public BoxCollider2D GetBoxCollider2D() { return _boxCollider2D; }

    [SerializeField] private Transform _possiblePlayerStartPos = null;
    public Transform GetPossiblePlayerStartPos() { return _possiblePlayerStartPos; }

    public Vector3 GetPosition() { return this.gameObject.transform.position; }
    public Vector3 GetLowestPosition() { return _boxCollider2D.bounds.min; }

    public Vector3 GetTriggerPosition() { return GetPosition(); }

    public bool IsActive() { return this.gameObject.activeInHierarchy; }

    public void Place(Vector3 startPoint)
    {
        var bounds = (Vector3)_boxCollider2D.size / 2f;
        bounds.x = _boxCollider2D.bounds.center.x;
        var centerStartPoint = startPoint - bounds;

        this.gameObject.transform.position = centerStartPoint;
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }
}
